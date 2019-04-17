using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    /// <summary>
    /// Muuttujat, joiden perusteella määrittyy millainen loppu pelille tulee.
    /// </summary>
    public int Karma = 0;
    public float Raha = 0;
    public int Viivytys = 0;
    public int Popcorn = 0;
    public int Leffa = 0;

    // haeejuut: lisätty rullaavaa indeksi valinnoille ja kello niiden välin mittaukseen
    public int valintaIndeksi = 0;
    public System.Diagnostics.Stopwatch kello = new System.Diagnostics.Stopwatch();

    /// <summary>
    /// Timeri, joka kertoo kuinka kauan peliä on pelattu.
    /// </summary>
    public float PelattuAika = 0;

    /// <summary>
    /// Jos pelaaja potkaisee pulloa, niin peli menee suoraan GameOver-paneeliin.
    /// </summary>
    public int PulloaPotkaistu = 0;

    public Text MoneyText;

    /// <summary>
    /// Tämä muuttuja pitää lukua siitä, miten paljon karmaa käyttäjällä on, kun lasketaan jokaisen pelikerran karmat yhteen.
    /// Tavallaan kertoo millainen pelaaja käyttäjä on yleisesti ottaen, eli tekeekö se paljon pahoja tekoja yms.
    /// Hidden karma pysyy tallennettuna vaikka peli suljetaan ja avataan uudelleen.
    /// </summary>
    private int hiddenKarma;
    

    private void Start()
    {
        // Kun peli käynnistetään, haetaan pelaajan hidden karma.
        hiddenKarma = PlayerPrefs.GetInt("hiddenKarma");

        // haeejuut: kello käyntiin valintojen välien mittausta varten
        kello.Start();
    }

    private void Update()
    {
        // Päivitetään timeri.
        PelattuAika += Time.deltaTime;
    }

    /// <summary>
    /// Päivittää UI-tekstit.
    /// </summary>
    public void UpdateTexts()
    {
        MoneyText.text = "Rahat: " + Raha + "€";
    }

    /// <summary>
    /// Päivittää käyttäjän hidden karman ja tallentaa sen.
    /// </summary>
    public void UpdateHiddenKarma()
    {
        hiddenKarma += Karma;
        PlayerPrefs.SetInt("hiddenKarma", hiddenKarma);
        PlayerPrefs.Save();
        Debug.Log("Hidden karma on: " + hiddenKarma);
    }

    
}
