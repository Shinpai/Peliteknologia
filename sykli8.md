## Raportti - Pelitestaus

[Takaisin sisällykseen](https://github.com/Shinpai/Peliteknologia)

* [Lataa projekti](https://github.com/Shinpai/Peliteknologia/raw/master/Sykli%208%20Pelitestaus/PongUnity.zip)
* [Lataa raportti](https://github.com/Shinpai/Peliteknologia/raw/master/Sykli%208%20Pelitestaus/testausraportti.pdf)

---
Aloitin syklin tutkailemalla annettua unityn dokumentaatiota testrunnerista. Ensivaikutelma on, että se on todella yksinkertaista ja helppo sisällyttää projektiin. Seuraavaksi lähdin miettimään testitapauksia, joka on todennäköisesti näin yksinkertaiselle sovellukselle haastavampi asia kuin itse työkalun käyttäminen. Siinä mielessä tehtävä tuntuukin minulle oudolta kun kyse on enemmän testauksesta ja raportoinnista kuin uusien peleissä käytettävien työkalujen ja teknologioiden opettelusta.

Päädyin todella typeriin yksikkötestauksiin, koska en keksinyt varsinkaan yksikkötestauksen puolella yhtään järkevää testattavaa kohtaa editorista.

Testicase 1 katsoo onko molemmissa pistetaulun <Text> objekteissa annetut alkuarvot oikeita, sekä samanlaisia (annoin niille alkuarvon 0). 
```csharp
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
---
