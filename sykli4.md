## Raportti - Pelitestaus

[Takaisin sisällykseen](https://github.com/Shinpai/Peliteknologia)

* [Unity projekti zippinä](https://github.com/Shinpai/Peliteknologia/tree/master/Sykli%208%20Pelitestaus)

---
Generointi oli minulle entuudestaan tuttu tapa tehdä karttoja ym, joten sain 3p tehtävät tehtyä aika sukkelasti. Päätin olla tekemättä 5p vaikka minulla oli valmiina muutama omatekemä koodinpätkä joitakin eri menetelmiä varten. Lähinnä laiskuuden ja aikataulun vuoksi jäin 3p suoritukseen. Päätin, että tehtävää varten tarpeeksi "mielekäs" asia vaihtaa on heksan väri, koska siihen voi mahdollisesti sitoa pelillisiä ominaisuuksia myös. Laitoin omat pari funktiota mitä tein suoraan karttasriptiin.

Ensimmäinen suoltaa normaalijakauman mukaan värin (käyttää siis vaan UnityEnginge.Random.Range:a):

```csharp
float r = UnityEngine.Random.Range(0, 1.0f);
if (r < .2f)
    return Color.black;
if (r < .4f)
    return Color.gray;
if (r < .6f)
    return Color.white;
if (r < .8f)
    return Color.cyan;
return Color.blue;
```

Toiselle voi asettaa rajat heksan sijainnin mukaan (ns. loogisesti ja haluttu määrä siis).

```csharp
string[] split = hexname.Split('_');
int x = int.Parse(split[1]);
int y = int.Parse(split[2]);
if (15 < x && x < 25)
    return Color.blue;
if (15 < y && y < 25)
    return Color.blue;
return Color.white;
```

Toisessa funktiossa olisi voinut käyttää vähän elegantimmin myös määriä hyväkseen, esim: tehdä heksalaskuri joka antaa laittaa 30 valkoista, 20 sinistä ja 10 punaista. Tai vaihtoehtoisesti riippuen naapureiden väristä arpoa uuden värin.

---
