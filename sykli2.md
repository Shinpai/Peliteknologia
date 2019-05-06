## Raportti - Peliohjelmoinnin erityispiirteet

[Takaisin sisällykseen](https://github.com/Shinpai/Peliteknologia)

* [Lataa buildi](https://github.com/Shinpai/Peliteknologia/raw/master/Sykli%202%20Peliohjelmoinnin%20erityispiirteet/build.zip)

Tämän tehtävän aloittaminen sujui melko helposti koska lähdemateriaali oli minulle entuudestaan tuttu. Aloitin kuitenkin siitä, että koettelin peliä ja miten se toimii. Tajusin vasta koodia tutkiessa, että siinä oli hypyn latausmahdollisuus. 

Lähdin liikkeelle updaten siivoamisesta. Tein lähes suoraan kirjan mukaisen InputHandler metodin jota update kutsuu. Tämä siis korvaamaan iso pätkä iffejä, joilla toiminnallisuus oli aikaisemmin tehty. 
Sitten mietin tarvittavat tilat pelaajalle, päädyin neljään:
```csharp
enum State
{
    STATE_GROUNDED,
    STATE_JUMPING,
    STATE_CHARGING,
    STATE_CHARGED
}
State current_state = State.STATE_GROUNDED;
```
Näihin nojaten kirjoitin sitten switch casen sisälle toiminnallisuuden per tila, sekä niiden väliset yhteydet. Näissä otin siis suoraan toiminnallisuuden aiemmasta updatesta ja liimasin oikeaan paikkaan InputHandleriin. OnCollisionEnterissä piti myös muistaa vaihtaa tila.

Päädyin myös vaihtamaan FixedUpdate -> Update:ksi, koska olen huomannut, että inputteja jää helposti pois fixedillä kun osuu framen väliin.

Seuraavaksi rupesin tekemään flyweight-mallia ja täytyy myöntää, että en ihan vieläkään ole satavarma mitä se on. Oletettavasti käytetään referenssejä uusien objektien sijaan (eli prefabeja?) ja generoidaan näiden avulla laitteistolle kevyemmin objekteja. Tein prefab pohjaisen toteutuksen kun siihen oli vinkattu tehtävässä. Tätä varten loin seuraavan luokan:

```csharp
class Pickable
{
    public string stype { get; set; }
    public Vector3 pos { get; set; }
    GameObject prefab { get; set; }    

    /// <summary>
    /// Constructor uudelle palikalle
    /// </summary>
    /// <param name="type"></param>
    public Pickable(int type)
    {
        // Palikan tyypin mukaan otetaan sille prefab ja sijainti
        switch (type)
        {
            case (0):
                stype = "ground";
                prefab = GameObject.Instantiate(Resources.Load("Prefabs/Pickable_ground")) as GameObject;
                pos = new Vector3(Random.Range(-8, 8), .5f, Random.Range(-8, 8));
                break;
            case (1):
                stype = "air";
                prefab = GameObject.Instantiate(Resources.Load("Prefabs/Pickable_air")) as GameObject;
                pos = new Vector3(Random.Range(-8, 8), 3f, Random.Range(-8, 8));
                break;
            case (2):
                stype = "special";
                prefab = GameObject.Instantiate(Resources.Load("Prefabs/Pickable_special")) as GameObject;
                pos = new Vector3(Random.Range(-8, 8), 6f, Random.Range(-8, 8));
                break;
            default:
                break;
        }
        prefab.transform.position = pos;
    }
}
``` 

Kuten näkee, otin olemassaolevat kolme palikkaa prefabiksi. Sitten vain luon ne constructorissa eri paikkaan laatikon sisään riippuen siitä minkälainen palikka oli kyseessä. Sen jälkeen vain generoin haluaamaani tyyppiä: new Pickable(0). Tein samaan scriptiin "PickableGenerator" listan jossa näitä sitten luon. Tämän laitoin playerobjectin komponentiksi.

Merkitsin kaikki muutokset haeejuut tagilla kommenttien sisään.
