using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartScene : MonoBehaviour
{
    // poorly named script that controls the two buttons in the current version of the game
    public void restart()
    {
        SceneManager.LoadScene(0);
    }
    public void stop()
    {
        Application.Quit();
    }
}
