using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class ScreenChanger : MonoBehaviour
    {
        public void ClickToStart()
        {
            GameManager.training = false;
            Debug.Log("Start Game");
            Time.timeScale = 1f;
            SceneManager.LoadScene("Scenes/MainGame");
        }

        public void ClickToStartAI()
        {
            GameManager.training = true;
            Debug.Log("Start Training");
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
    }
}