using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnSnek : MonoBehaviour
{
    public void Respawn()
    {
        SceneManager.LoadScene("SinglePlayer");
    }
    
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
