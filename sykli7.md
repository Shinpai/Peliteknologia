## Raportti - Virtuaalitodellisuus

[Takaisin sisällykseen](https://github.com/Shinpai/Peliteknologia)

* [Lataa Unity-paketti tästä]()

---

Lähdin tekemään mobiiliversiota virtuaalitodellisuustehtävästä. Paketin luettua rupesin katselemaan GoogleVR paketissa olevia prefabeja ja sieltä löytyikin pakolliseen tarvittava GVREditorEmulator. Seuraavaksi etsin tähtäintä varten prefabia ja siihen löytyi Reticle pointer prefabi. Siitä joutui muokkaamaan transformin paikkaa, sekä materiaalin propertyja jotta sai turhat reunat pois kameran tieltä.

Rupesin tekemään raycastia reticlepointerin kautta sillä tavalla, että kutsuin reticlepointer scriptiä omasta scriptistä joka oli kiinni samassa objektissa. Tämän reticlepointerin raycastin toimintaan saattaminen ei kuitenkaan onnistunut hirveän yksinkertaisesti tai en löytänyt kunnon dokumentaatiota siihen. Päädyin tekemään perinteisemmän kamerassa kiinni olevan raycasterin (hitscan), koska se oli tutta ja paljon yksinkertaisemmin tehty muutamalla pätkällä koodia.

Rupesin sitten raycastin päälle tekemään switch casen eri tapauksista. Muutamia erikoistapauksia piti ottaa huomioon, kuten teleporttaaminen hattu päässä ym. Muuten oli kyllä erittäin suoraviivainen tehdä tällä tavalla eikä vaatinut hirveästi ajattelua. Varmaan vaatisi pientä tutkimusta jos ei tiedä raycastingistä mitään, mutta aika lailla unityn dokumentaatiosta löytyy suoraan vastaus.

Tein ajastimen visualisoinnin sisäänrakennetulla imagekomponentin radial fillillä, yhdistin sen counteriin joka ajastaa raycastin osumia.

---