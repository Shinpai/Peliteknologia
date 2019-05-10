using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pelaajan mailan liikuuttamisen toteutus
/// </summary>
public class Movement : MonoBehaviour
{

    public float speed;

    //Nopeuden asettaminen
    void Start()
    {

        //Asetetaan alkunopeus
        speed = 8f;
    }

    //Liikuttamisen toteuttaminen ja tarkistetaan, ettei mene rajojen ulkopuolelle
    void Update()
    {
        //Pelaajan maila liikkuu tietylla nopeudella ja tiettyyn suuntaan,
        //kun painetaan nuolinappaimia ylos ja alas tai w ja s
        float isMoving = speed * Input.GetAxis("Vertical") * Time.deltaTime;
       
        //Tarkistetaan, ettei maila mene yli reunoista
        if (transform.position.y < -5.0 && isMoving < 0)
        {
            isMoving = 0;
        }

        if (transform.position.y > 4.7 && isMoving > 0)
        {
            isMoving = 0;
        }

        transform.Translate(0f, isMoving, 0f);
    }
}
