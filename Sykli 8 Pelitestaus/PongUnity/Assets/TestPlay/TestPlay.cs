using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestPlay
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestPlaySimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestPlayWithEnumeratorPasses()
        {
            // ladataan skene ja odotetaan sen latausta puoli sekuntia
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
        }
    }
}
