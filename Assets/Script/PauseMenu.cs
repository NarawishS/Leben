using UnityEngine;

namespace Script
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject pauseMenuPanel;
        public GameObject board;
        public GameObject playerPanel;
        public GameObject playerFrame;

        public void Pause()
        {
            if (!pauseMenuPanel.activeSelf)
            {
                pauseMenuPanel.SetActive(true);
                Time.timeScale = 0f;
                board.SetActive(false);
                playerPanel.SetActive(false);
                playerFrame.SetActive(false);
            }
        }

        public void Resume()
        {
            pauseMenuPanel.SetActive(false);
            Time.timeScale = 1f;
            board.SetActive(true);
            playerPanel.SetActive(true);
            playerFrame.SetActive(true);
        }
    }
}