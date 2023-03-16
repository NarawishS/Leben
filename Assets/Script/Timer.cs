using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class Timer : MonoBehaviour
    {
        private float _timeValue = 60f;
        public Text timeText;
        private float _elapsed = 0f;
        public GameObject home;

        // Update is called once per frame
        private void Update()
        {
            _elapsed += Time.deltaTime;

            if (_timeValue > 0)
            {
                _timeValue -= Time.deltaTime;
            }
            else
            {
                switch (GameManager.Instance.state)
                {
                    case GameState.P1Turn:
                        GameManager.Instance.player1.transform.DOMove(new Vector3(-0.1839f, 2.8835f), 0.5f)
                            .SetEase(Ease.InOutQuad);
                        GameManager.Instance.UpdateGameState(GameState.P2Turn);
                        GameManager.Instance.UpdateTurn();
                        break;
                    case GameState.P2Turn:
                        GameManager.Instance.player2.transform.DOMove(new Vector3(-0.1839f, 2.8835f), 0.5f)
                            .SetEase(Ease.InOutQuad);
                        GameManager.Instance.UpdateGameState(GameState.P1Turn);
                        GameManager.Instance.UpdateTurn();
                        break;
                }

                _timeValue = 60;
                Player player;
                switch (GameManager.Instance.state)
                {
                    case GameState.P1Turn:
                        player = GameManager.Instance.player1;
                        break;

                    case GameState.P2Turn:
                        player = GameManager.Instance.player2;
                        break;
                    default:
                        player = GameManager.Instance.player1;
                        break;
                }
                
                if (player.GetInfectionStatus())
                {
                    Debug.Log($"{player.name} is infected");
                    _timeValue /= 2;
                }
                else
                {
                    player.SetInfectionStatus(
                        ProbabilityManager.ProbabilityCheckByPercent(player.GetInfectionChance()));
                    if (player.GetInfectionStatus())
                    {
                        Debug.Log($"{player.name} is infected");
                        _timeValue /= 2;
                    }
                }

                player.SetInfectionChance(0);
            }

            if (_elapsed >= 1f)
            {
                _elapsed %= 1f;
                GetComponent<Text>().color = Color.black;
            }

            DisplayTime(_timeValue);
        }

        public void DecreaseTime(int t)
        {
            GetComponent<Text>().color = Color.red;
            _timeValue -= t;
        }

        public void ResetTime()
        {
            _timeValue = 0;
        }

        private void DisplayTime(float timeToDisplay)
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