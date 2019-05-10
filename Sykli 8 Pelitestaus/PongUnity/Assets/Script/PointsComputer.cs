using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Vastustajan (tietokoneen) pisteista huolehtiminen
/// </summary>
public class PointsComputer : MonoBehaviour
{

    public Text pointsComputer;

    public static int pointsValue = 0;

    //Asetetaan alkuarvot
    void Start()
    {
        pointsComputer = GetComponent<Text>();
    }

    //Pisteiden kirjaamisesta huolehtiminen
    void Update()
    {
        pointsComputer.text = "" + pointsValue;
    }
}
