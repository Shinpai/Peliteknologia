## Raportti - Pelitestaus

[Takaisin sisällykseen](https://github.com/Shinpai/Peliteknologia)

* [Unity projekti zippinä]()

---
Olin juuri gamejamissa tehnyt samanlaiset jutut muutama viikko takaperin (touch input ja apk pakkaus), joten käytin lähinnä niissä käyttämääni koodia. Aloitin tehtävän muokkaamalla aluksen ShipShoot scriptiä järkevämmäksi. Tein siihen updateen TouchHandler funktion.

Lyhykäisyydessään tein 3p tehtäviä kahdella funktiolla sekä updatessa olevalla kikkareella joka ottaa kiinni kosketuksen tiedot. Long pressiä varten tarvitsi joko pyörivän counterin tai ajastimen, päädyin kokeilemaan c# diagnostiikka stopwatchia, joka näytti toimivan tässä ihan pätevästi.

Updaten sisällä:

```csharp
foreach (Touch touch  in Input.touches)
{   
    // otetaan talteen id, positiovektori ja phase
    TouchHandler(touch.fingerId, 
                 Camera.main.ScreenToWorldPoint(touch.position),
                 touch.phase);
}
```

Sitten touchhandler joka ottaa tiedot siitä vastaan ja tekee tapauksittain jotain

```csharp
// liikutus
if (timer.Elapsed.Seconds >= 1)
    Move(pos);
// eri phase keissit erilleen
switch (phase)
{
    case TouchPhase.Began:
        timer.Start();
        break;
    case TouchPhase.Ended:
        if (timer.Elapsed.Seconds < 1)
            Shoot(false);
        timer.Stop();
        timer.Reset();
        break;
}
```

Ja lopuksi liikkumisfunktio, sille en asettanut mitää rajoja joten sinkoaa ulos ruudulta jos niin tahtoo

```csharp
if (pos.x < 0)
    transform.Translate(.05f, 0, 0);
else
    transform.Translate(-.05f, 0, 0);
```

---
