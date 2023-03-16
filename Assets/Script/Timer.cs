using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class Timer : MonoBehaviour
    {
        private float timeValue = 60f;
        public Text timeText;
        private float elapsed = 0f;
        public GameObject home;

        // Update is called once per frame
        void Update()
        {
            elapsed += Time.deltaTime;

            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                switch (GameManager.Instance.state)
                {
                    case GameState.P1Turn:
                        GameManager.Instance.player1.transform.DOMove(new Vector3(-0.1839f,2.8835f), 0.5f).SetEase(Ease.InOutQuad);
                        GameManager.Instance.UpdateGameState(GameState.P2Turn);
                        GameManager.Instance.UpdateTurn();
                        break;
                    case GameState.P2Turn:
                        GameManager.Instance.player2.transform.DOMove(new Vector3(-0.1839f,2.8835f), 0.5f).SetEase(Ease.InOutQuad);
                        GameManager.Instance.UpdateGameState(GameState.P1Turn);
                        GameManager.Instance.UpdateTurn();
                        break;
                }

                timeValue = 60;
            }

            if (elapsed >= 1f)
            {
                elapsed %= 1f;
                GetComponent<Text>().color = Color.black;
            }

            DisplayTime(timeValue);
        }

        public void DecreaseTime(int t)
        {
            GetComponent<Text>().color = Color.red;
            timeValue -= t;
        }

        public void ResetTime()
        {
            timeValue = 0;
        }

        void DisplayTime(float timeToDisplay)
        {
            if (timeToDisplay < 0)
            {
                timeToDisplay = 0;
            }

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}

