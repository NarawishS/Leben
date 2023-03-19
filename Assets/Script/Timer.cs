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
                Player player;
                if (GameManager.Instance.state.Equals(GameState.P1Turn))
                {
                    player = GameManager.Instance.player1;
                    player.transform.DOMove(new Vector3(-0.1839f, 2.8835f), 0.5f).SetEase(Ease.InOutQuad);

                    GameManager.Instance.UpdateGameState(GameState.P2Turn);
                    GameManager.Instance.UpdateTurn();

                    player = GameManager.Instance.player2;
                }
                else
                {
                    player = GameManager.Instance.player2;
                    player.transform.DOMove(new Vector3(-0.1839f, 2.8835f), 0.5f).SetEase(Ease.InOutQuad);

                    GameManager.Instance.UpdateGameState(GameState.P1Turn);
                    GameManager.Instance.UpdateTurn();

                    player = GameManager.Instance.player1;
                }

                _timeValue = 60f;

                if (player.GetInfectionStatus())
                {
                    Debug.Log($"{player.name} is infected");
                    _timeValue *= 0.25f;

                    if (player.GetMask() > 0)
                    {
                        player.SetMask(-1);
                    }
                }
                else
                {
                    float infectionChance = player.GetInfectionChance();

                    if (player.GetMask() > 0)
                    {
                        infectionChance *= 0.5f;
                        player.SetMask(-1);
                    }

                    player.SetInfectionStatus(
                        ProbabilityManager.ProbabilityCheckByPercent(Mathf.FloorToInt(infectionChance)));

                    if (player.GetInfectionStatus())
                    {
                        Debug.Log($"{player.name} is infected");
                        _timeValue *= 0.4f;
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

        public void DecreaseTime(float t)
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