## Raportti - Pelitestaus

[Takaisin sisällykseen](https://github.com/Shinpai/Peliteknologia)

* [Lataa projekti](https://github.com/Shinpai/Peliteknologia/raw/master/Sykli%208%20Pelitestaus/PongUnity.zip)
* [Lataa raportti](https://github.com/Shinpai/Peliteknologia/raw/master/Sykli%208%20Pelitestaus/testausraportti.pdf)

---

Korjaukset 17.05.2019:

Testauksen ongelmat johtuivat siitä, että en ymmärtänyt editor/playmode eroja tarpeeksi hyvin. Vaihdettuani testit playmoden ja etenkin pois simplepass osiosta Ienumerator puolelle, sain testit toimimaan halutulla tavalla ja skenen objektit kiinni. Build settingsiin joutui lisäämään aktiivisen skenen kun se oli sieltä pompannut pois.

Nyt testit toimivat halutusti: tarkistaa onko pisteytys oikein pelin alussa ja onko objektit luotu.

Raportin puolesta lisäsin pyydettyihin osioihin 1.3 kuvaukseen sekä luvun 2 testitapauksien yksilöintiin.

En ymmärtänyt mitä osiossa 1.4 tulisi kertoa työkalusta: "Kuvaa tähän, mitä sait selville Unity Test Runner -testaustyökalun toiminnasta." kysyy mielestäni mielipidettäni ja oppimisprosessia jota olen kuvaillut tässä dokumentissa. Taas otsikko "1.4 Testaustyökalun kuvaaminen" viittaisi siihen, että selvitän lukijalle mitä työkalua testauksessa käytettiin. Korjasin tämän nyt jälkimmäisen mukaiseksi.

Jätin muutamat välitekstit mallipohjasta sikseen, koska oletin niiden olevan metatekstiä ie. "tässä luvussa puhutaan tästä asiasta". Kolmanteen lukuun ne vain unohtuivat. Ne on nyt poistettu.

---

Aloitin syklin tutkailemalla annettua unityn dokumentaatiota testrunnerista. Ensivaikutelma on, että se on todella yksinkertaista ja helppo sisällyttää projektiin. Seuraavaksi lähdin miettimään testitapauksia, joka on todennäköisesti näin yksinkertaiselle sovellukselle haastavampi asia kuin itse työkalun käyttäminen. Siinä mielessä tehtävä tuntuukin minulle oudolta kun kyse on enemmän testauksesta ja raportoinnista kuin uusien peleissä käytettävien työkalujen ja teknologioiden opettelusta.

Päädyin todella typeriin yksikkötestauksiin, koska en keksinyt varsinkaan yksikkötestauksen puolella yhtään järkevää testattavaa kohtaa editorista.

Testicase 1 katsoo onko molemmissa pistetaulun <Text> objekteissa annetut alkuarvot oikeita, sekä samanlaisia (annoin niille alkuarvon 0). 
    
```csharp
// ladataan skene ja odotetaan sen lataus
UnityEngine.SceneManagement.SceneManager.LoadScene(0);
yield return new WaitForSeconds(1);    
// CASE 1
// Pistetekstien luominen
var pogo = GameObject.Find("Points");
var potext = pogo.GetComponent<Text>();
Assert.AreEqual("0", potext.text);
var cogo = GameObject.Find("ComputerPoints");
var cotext = cogo.GetComponent<Text>();
Assert.AreEqual("0", cotext.text);
// Onko tekstit samat
Assert.AreEqual(potext.text, cotext.text);
```

Testicase2 katsoo onko kaikki pelaamiseen välttämätön olemassa: mailat, pallo sekä reunat.
```csharp
// CASE 2
// Tarkistetaan onko pelaamiseen tarvitut objektit olemassa
var maila = GameObject.Find("Player");
var maila2 = GameObject.Find("Computer");
var pallo = GameObject.Find("Ball");
var seinat = GameObject.FindGameObjectsWithTag("seina");
Assert.IsNotNull(maila, "Pelaajan mailaa ei löytynyt");
Assert.IsNotNull(maila2, "AI:n mailaa ei löytynyt");
Assert.IsNotNull(pallo, "Palloa ei löytynyt");
foreach (var s in seinat)
{
    Assert.IsNotNull(s, "Seinä puuttuu");
}
```
Lopuksi napsuttelin mallipohjaan hyvin suppean raportin näistä parista yksikkötestistä.

---
