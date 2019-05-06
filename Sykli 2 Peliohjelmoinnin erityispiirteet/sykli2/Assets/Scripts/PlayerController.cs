using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    Renderer rend;

    Material playerNormal;
    Material playerCharge;
    Material playerChargeFull;
    Material playerSuper;

    private Rigidbody rb;
    private int count;
    private int speed;

    private int charge;
    private int maxCharge;

    Vector3 jump;
    Vector3 superJump;

    bool isJumping;
    bool isSuperJumping;
    bool isCharging;
    bool isCharged;



    private void Start()
    {
        rend = GetComponent<Renderer>();

        playerNormal = Resources.Load("Materials/Player", typeof(Material)) as Material;
        playerCharge = Resources.Load("Materials/PlayerCharge", typeof(Material)) as Material;
        playerChargeFull = Resources.Load("Materials/PlayerChargeFull", typeof(Material)) as Material;
        playerSuper = Resources.Load("Materials/PlayerSuper", typeof(Material)) as Material;

        rb = GetComponent<Rigidbody>();
        count = 0;
        speed = 10;

        charge = 0;
        maxCharge = 50;

        jump = new Vector3(0, 400, 0);
        superJump = new Vector3(0, 1000, 0);

        isJumping = false;
        isSuperJumping = false;
        isCharging = false;
        isCharged = false;
    }

    //haeejuut: State machine ja input handler
    enum State
    {
        STATE_GROUNDED,
        STATE_JUMPING,
        STATE_CHARGING,
        STATE_CHARGED
    }
    State current_state = State.STATE_GROUNDED;
    private void inputHandler()
    {
        // Input.GetKeyDown(KeyCode.Space);
        switch (current_state)
        {
            // alkutilanteen  tapaukset ja materiaalin nollaus
            case State.STATE_GROUNDED:
                // materiaalin nollaus
                changeMaterial(playerNormal);
                // perushyppy
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(jump);
                    current_state = State.STATE_JUMPING;
                }
                // aloitetaan lataus
                else if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    current_state = State.STATE_CHARGING;
                }
                break;
            // Tyhjä mutta tarpeellinen
            case State.STATE_JUMPING:
                break;
            // ladattava hyppy
            case State.STATE_CHARGING:
                changeMaterial(playerCharge);
                charge++;
                // jos päästää irti ennen maksimia
                if (Input.GetKeyUp(KeyCode.LeftControl))
                {
                    changeMaterial(playerNormal);
                    current_state = State.STATE_GROUNDED;
                }
                // jos menee maksimiin asti
                else if (charge > maxCharge)
                {
                    changeMaterial(playerChargeFull);
                    current_state = State.STATE_CHARGED;
                }
                break;
            // ladattu täysille
            case State.STATE_CHARGED:
                // nollataan mittari
                charge = 0;
                // päästetään irti 
                if (Input.GetKeyUp(KeyCode.LeftControl))
                {
                    rb.AddForce(superJump);
                    changeMaterial(playerSuper);
                    current_state = State.STATE_JUMPING;
                }
                break;
            default:
                break;
        }
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);

        if (rb.transform.position.y < 0)
        {
            restartGame();
        }

        // haeejuut: iffittely korvattu tällä
        inputHandler();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //haeejuut
            current_state = State.STATE_GROUNDED;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;

            if (count >= 10)
            {
                restartGame();
            }
        }
    }

    void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void changeMaterial(Material material)
    {
        Material[] mats = rend.materials;
        mats[0] = material;
        rend.materials = mats;
    }

}
