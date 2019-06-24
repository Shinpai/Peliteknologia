## Raportti - Mobiilipeli

[Takaisin sisällykseen](https://github.com/Shinpai/Peliteknologia)

* [Unity projekti zippinä](https://github.com/Shinpai/Peliteknologia/raw/master/Sykli%205%20Mobiilialustat/Mobile-master.7z)
* [APK](https://github.com/Shinpai/Peliteknologia/raw/master/Sykli%205%20Mobiilialustat/sykli5.apk)

---
Olin juuri gamejamissa tehnyt samanlaiset jutut muutama viikko takaperin (touch input ja android apk pakkaus), joten käytin lähinnä niissä käyttämääni koodia ja valmista konffausta. Aloitin tehtävän muokkaamalla aluksen ShipShoot scriptiä järkevämmäksi omia käyttötarkoituksia varten. Tein sitten updateen TouchHandler funktion, sekä liikkumiselle oman funktion.

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
