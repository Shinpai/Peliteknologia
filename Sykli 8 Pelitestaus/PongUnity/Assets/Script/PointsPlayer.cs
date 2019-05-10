using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Pelaajan pisteiden laskemisesta huolehtiminen
/// </summary>
public class PointsPlayer : MonoBehaviour
{

    public Text pointsPlayer;

    public static int pointsValue = 0;

    //Alkuarvojen sijoittaminen
    void Start()
    {
        pointsPlayer = GetComponent<Text>();
    }

    //Pisteiden kirjaamisesta huolehtiminen
    void Update()
    {
        pointsPlayer.text = "" + pointsValue;
    }
}
