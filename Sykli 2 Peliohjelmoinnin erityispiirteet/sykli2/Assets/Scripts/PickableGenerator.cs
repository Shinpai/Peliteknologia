using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// haeejuut
public class PickableGenerator : MonoBehaviour
{
    List<Pickable> all_pickables;
    void Start()
    {
        // tehdään lista palikoita jotka luodaan kentälle
        all_pickables = new List<Pickable>();

        all_pickables.Add(new Pickable(0));
        all_pickables.Add(new Pickable(0));
        all_pickables.Add(new Pickable(0));
        all_pickables.Add(new Pickable(0));

        all_pickables.Add(new Pickable(1));
        all_pickables.Add(new Pickable(1));

        all_pickables.Add(new Pickable(2));

        foreach (Pickable p in all_pickables)
        {
            Debug.Log(string.Format("Pickable type {0} at [{1},{2}]", p.stype, p.pos.x, p.pos.y));
        }
    }
}

class Pickable
{
    public string stype { get; set; }
    public Vector3 pos { get; set; }
    GameObject prefab { get; set; }    

    /// <summary>
    /// Constructor uudelle palikalle
    /// </summary>
    /// <param name="type"></param>
    public Pickable(int type)
    {
        // Palikan tyypin mukaan otetaan sille prefab ja sijainti
        switch (type)
        {
            case (0):
                stype = "ground";
                prefab = GameObject.Instantiate(Resources.Load("Prefabs/Pickable_ground")) as GameObject;
                pos = new Vector3(Random.Range(-8, 8), .5f, Random.Range(-8, 8));
                break;
            case (1):
                stype = "air";
                prefab = GameObject.Instantiate(Resources.Load("Prefabs/Pickable_air")) as GameObject;
                pos = new Vector3(Random.Range(-8, 8), 3f, Random.Range(-8, 8));
                break;
            case (2):
                stype = "special";
                prefab = GameObject.Instantiate(Resources.Load("Prefabs/Pickable_special")) as GameObject;
                pos = new Vector3(Random.Range(-8, 8), 6f, Random.Range(-8, 8));
                break;
            default:
                break;
        }
        prefab.transform.position = pos;
    }
}
