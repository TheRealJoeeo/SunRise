using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void exitGame()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          exitGame();  
        }
    }
}
