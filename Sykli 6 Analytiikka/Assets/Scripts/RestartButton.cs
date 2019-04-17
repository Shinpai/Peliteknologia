using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    /// <summary>
    /// Restarttaa scenen.
    /// </summary>
    public void OnButtonPress()
    {
        SceneManager.LoadScene(0);
    }
}
