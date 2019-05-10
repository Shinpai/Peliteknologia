using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pallon liikkumisen toteuttaminen, pisteiden antaminen ja tormayksien kasitteleminen
/// </summary>
public class BallMovement : MonoBehaviour
{
    Vector2 ballDirection;
    public float speed;
    float ra;

    //Asetetaan alkunopeus ja suunta
    void Start()
    {
        speed = 9f;
        ballDirection = Vector2.one.normalized;
        ra = transform.localScale.x / 2;
    }

    //Muutetaan pallon suuntaa kun se tormaa yla tai ala seiniin
    //Kasitellaan se, kun pallo menee ohi pelaajan tai vastustajan mailasta ja annetaan tieto
    //kenelle pisteita tulee antaa
    void Update()
    {
        transform.Translate(ballDirection * Time.deltaTime * speed);

        if (transform.position.y < -5.0 + ra && ballDirection.y < 0)
        {
            ballDirection.y = -ballDirection.y;
        }

        if (transform.position.y > 5.5 - ra && ballDirection.y > 0)
        {
            ballDirection.y = -ballDirection.y;
        }

        //You win
        if (transform.position.x > 10.5 - ra && ballDirection.x > 0)
        {
            Debug.Log("You win!");
            PointsPlayer.pointsValue += 1;
            this.transform.position = new Vector3(0f, 0f, 0f);
            //Time.timeScale = 0;
            //enabled = false;
        }

        //You lose
        if (transform.position.x < -10.5 + ra && ballDirection.x < 0)
        {
            Debug.Log("You lose!");
            PointsComputer.pointsValue += 1;
            this.transform.position = new Vector3(0f, 0f, 0f);
            //Time.timeScale = 0;
            //enabled = false;
        }
    }

    //Kuinka tormays kasitellaan kun osutaan pelaajan tai vastustajan mailaan x akselilla
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If player hit ball
        if (collision.tag == "Paddle")
        {
            if (ballDirection.x < 0)
            {
                ballDirection.x = -ballDirection.x;
            }
        }

        //If computer hit ball
        if (collision.tag == "PaddleComputer")
        {
            if (ballDirection.x > 0)
            {
                ballDirection.x = -ballDirection.x;
            }
        }
    }
}
