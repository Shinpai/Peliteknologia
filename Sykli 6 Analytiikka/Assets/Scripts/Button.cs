using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class Button : MonoBehaviour
{
    // Paneeli, johon siirrytään kun tätä painiketta painetaan.
    public RectTransform NextPanel;

    public GameController GameController;

    /// <summary>
    /// Alla olevat julkiset muuttujat kertovat, miten paljon kyseistä asiaa lisätään GameControllerin saman nimisiin arvoihin kun kyseistä painiketta painetaan.
    /// Muuttujat ovat julkisia, jotta voidaan tarvittaessa editorin kautta helposti muuttaa näitä arvoja.
    /// </summary>
    public int KarmaMuutos = 0;
    public float RahaMuutos = 0;
    public int Viivytys = 0;
    public int PopcornitMuutos = 0;
    public int LeffaMuutos = 0;
    public int PulloaPotkaistuMuutos = 0;

    
    public void OnButtonPress()
    {
        GameController.Karma += KarmaMuutos;
        GameController.Raha += RahaMuutos;
        GameController.Viivytys += Viivytys;
        GameController.Popcorn += PopcornitMuutos;
        GameController.Leffa += LeffaMuutos;
        GameController.PulloaPotkaistu += PulloaPotkaistuMuutos;

        // haeejuut: aika talteen kellosta
        System.TimeSpan valinta_ts = GameController.kello.Elapsed;
        int valinta_aika = valinta_ts.Seconds;
        GameController.kello.Restart();

        // parametrit nätimmin
        var param_raha = (int)GameController.Raha;
        var param_karma = GameController.Karma;
        var param_aika = valinta_aika;
        Debug.Log(string.Format("raha : {0}, karma : {1}, aika {2}", param_raha, param_karma, param_aika));

        // joka valinnalle oma event jossa otetaan resurssit parametrina    
        if (NextPanel != transform.parent.gameObject.GetComponent<RectTransform>())
        {
            string nimi = "valinta_" + GameController.valintaIndeksi.ToString();
            Analytics.CustomEvent(nimi, new Dictionary<string, object>
            {
                { "raha", param_raha },
                { "karma", param_karma },
                { "aika(s)", param_aika }
            });
            GameController.valintaIndeksi += 1;
        }  
        // end haeejuut

        GameController.UpdateTexts();

        // Disabloidaan nykyinen paneeli ja aktivoidaan seuraava.
        transform.parent.gameObject.SetActive(false);
        NextPanel.gameObject.SetActive(true);
    }
}
