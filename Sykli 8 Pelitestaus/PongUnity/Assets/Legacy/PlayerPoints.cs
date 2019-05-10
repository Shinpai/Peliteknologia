using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// EI KAYTOSSA
/// </summary>
public class PlayerPoint : MonoBehaviour
{

    public static PlayerPoint controller;

    public Text points;
    public Text computerPoints;

    public static int pointsValue = 0;
    public static int computerPointsValue = 0;

    // Aluksi asetetaan teksti pisteisiin
    void Start()
    {
        controller = this;

        points = GetComponent<Text>();
        computerPoints = GetComponent<Text>();
    }

    // Paivitetaan pelaajan pisteita
    void Update()
    {
        points.text = "" + pointsValue;
        computerPoints.text = "" + computerPointsValue;
    }
}
