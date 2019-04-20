## Raportti - Pelimoottorit

[Takaisin sisällykseen](https://github.com/Shinpai/Peliteknologia)

Lähdin tekemään ensimmäistä versiota pygame-moottorilla, koska python on tuttua kauraa ja olen kuullut pygamesta aikaisemmin. Nappasin netistä template filun nopeuttamaan prosessia. Tämä antoi minulle käytännössä tyhjän mustan ruudun valmiiksi konfiguroituun ikkunaan kun tiedoston ajoi.

Tämän jälkeen rupesin hahmottelemaan core looppia ja mitä siihen tarvitaan. Kävin katsomassa annettua khanacademy linkkiä tueksi ja sain niiltä pohjilta oman pseudokoodiversion valmiiksi (lue: python versio). 

Suurimmat kompastuskivet pygamen kanssa oli sen paketointi, jonka kanssa piti turvautua erillisiin kirjastoihin. Käytin tässä cx_Freeze pakettia apuna. Sen konfigurointia hetken tuumailtua sain windowsilla ajettavan paketin ulos.

Pygame-version paketoinnin jälkeen rupesin miettimään millä tekisin toisen version ja päädyin siihen, että haluaisin koettaa beta-versiossa olevaa Amazonin Lumberyard- ympäristöä joka ilmeisesti pohjautuu CryEngineen. Sen kanssa muutaman tunnin räpellettyä, totesin että ei ole ihmisten hommaa ja rupesin etsimään vaihtoehtoista ympäristöä.

![Kuvapohja](img/s01_00.jpg)
Pohja