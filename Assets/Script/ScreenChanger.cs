using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenChanger : MonoBehaviour
{

    public void ClickToStart()
    {
        Debug.Log("Start Game");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/MainGame");
    }

    public void ClickToQuit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    
    public void BackToMenu()
    {
        Debug.Log("Back to Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/MainMenu");
    }
    
    public static void GameEnd()
    {
        Debug.Log("Game Ended");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/EndGame");
    }
}
