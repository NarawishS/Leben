using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class ScreenChanger : MonoBehaviour
    {
        public void ClickToStart()
        {
            GameManager.Training = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene("Scenes/MainGame");
        }

        public void ClickToStartAI()
        {
            GameManager.Training = true;
            Time.timeScale = 1f;
            SceneManager.LoadScene("Scenes/MainGame");
        }

        public void ClickToQuit()
        {
            Application.Quit();
        }

        public void BackToMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Scenes/MainMenu");
        }
    }
}