using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void SinglePlayer()
    {
        SceneManager.LoadScene("SinglePlayer");
    }

    public void MultiPlayer()
    {
        SceneManager.LoadScene("MultiPlayer");
    }
}
