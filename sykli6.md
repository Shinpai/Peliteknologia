## Raportti - Analytiikkatyökalut

[Takaisin sisällykseen](https://github.com/Shinpai/Peliteknologia)

* [Lataa Unity-paketti tästä](https://github.com/Shinpai/Peliteknologia/raw/master/Sykli%206%20Analytiikka/Sykli6_project.zip)

---

Aloitin siitä, että koetin peliä muutaman kerran. Sen jälkeen löin analytiikan päälle ja rupesin kurkkimaan dokumentaatiota siitä, miten parametrit saa kulkemaan niiden kanssa. Päätin jo suht alussa, että teen mieluummin koodin sisään event-kutsun kuin rupean säätämään komponentteja gameobjectien sisään. Näin ollen piti siis ruveta katselemaan koodia ja missä vaiheessa mikäkin suoritetaan.

![pakollinen](img/s6_00.jpg)
*Muutamien päivien ajalta keskiarvot*

Ensimmäisen pisteen suoritus oli helposti tehty dokumentaation avulla, seuraavaksi rupean katsomaan saisiko funnelia varten eri valintojen eventit tehtyä "koodillisesti" vai pitääkö tukeutua komponentteihin. 

---

![funnel0](img/s6_01.jpg)
*Ensimmäisen funnelin käppyrät*

--> Päädyin tekemään buttonscriptiin eventin joka triggeroituu kun nappia painetaan ja antaa numeroidun valinnan analytics eventtinä. Sitten tein funnelin, jossa valinnat 1-4 ja gameover. 

Funnel näyttäisi toimivan muuten, mutta ei rekisteröi "karma"- resurssia vaikka se on tehty samalla tavoin kuin muut resurssit eli haettu GameController luokalta. Tämä on sitten ilmeisesti niitä tehtävänannossa mainittuja ominaisuuksia mitä tuolta löytyy. 

![funnel1](img/s6_02.jpg)
*Ensimmäisen funnelin config*

Kaikki koodimuutokset merkitty 'haeejuut' tagilla. Loppujen lopuksi tein vaan kaksi custom-eventtiä: GAMEOVER_EVENT ja valinta_ jossa juokseva indeksi perässä. Näitä tukemaan laitoin indeksin GameControlleriin kiinni, sekä ajoitusta varten StopWatch olion myös GameControlleriin.

Tein viimeisenä pieniä muutoksia GAMEOVER_EVENT:iin, koska huomasin vasta, että se ei tulittanut kaikissa tapauksissa kuten pullon potkaisussa. Lisäsin GameOver.cs:ään GameOverTrigger metodin jonka työnsin sitten OnEnablen loppuun, sekä erikoistapauksiin: pullo ja popkornit + leffa.

Näillä muutoksilla pitäisi toisen funnelin olla aika suoraviivainen (olettaen, että eventit menee sille läpi).

![funnel1](img/s6_03.jpg)
*Pullofunnelin käppyrä*

![funnel1](img/s6_04.jpg)
*Pullofunnelin config*

Tein vielä achievement funnelin samalla kun laitoin pullonpotkaisufunnelin "vetämään". Vaatii, että valitsee "jatka matkaa" pullonpotkaisukohdassa, sekä vähintään yhden näpistämisen.

![funnel1](img/s6_05.jpg)
*Achifunnelin config*



