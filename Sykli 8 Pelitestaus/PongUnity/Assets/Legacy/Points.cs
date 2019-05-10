using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public static Points controller;

    public Text points;
    public Text computerPoints;

    public static int pointsValue = 0;
    public static int computerPointsValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = this;

        points = GetComponent<Text>();
        computerPoints = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        points.text = "" + pointsValue;
        computerPoints.text = "" + computerPointsValue;
    }
}
