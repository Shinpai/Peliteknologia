using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tietokoneen ohjaaman mailan liikkeet
/// </summary>
public class ComputerMovement : MonoBehaviour
{
    public float speed;

    public GameObject ball;
    public Transform ballPosition;
    Vector3 position;

    //Asetetaan nopeus
    void Start()
    {
        speed = 8f;
    }

    //Tarkistetaan ettei maila mene ohi yla tai alareunasta ja laitetaan vastustajan (tietokoneen)
    //maila seuraamaan palloa
    void Update()
    {
        float isMoving = speed * Time.deltaTime;

        //Katsoo missä pallo ja liikkuu sinne suuntaan
        position = (ballPosition.position - transform.position).normalized;

        //Tarkistetaan, ettei vastustaja mene yli rajojen
        if (transform.position.y < -5.0 && isMoving < 0)
        {
            isMoving = 0;
        }

        if (transform.position.y > 4.7 && isMoving > 0)
        {
            isMoving = 0;
        }

        transform.Translate(0f, position.y * isMoving, 0f);

        
    }
}
