using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public GameState state;
        public GameObject p1;
        public GameObject p2;
        public GameObject p1frame;
        public GameObject p2frame;
        public Player player1;
        public Player player2;
        public List<Player> playerList;
        public List<Player> scoreOrderedPlayerList;

        public Timer timer;
        public GameObject infectionPanel;
        public GameObject hungryPanel;
        public GameObject diarrheaPanel;

        private float _turnCount = 1f;
        private float _maxTurn = 10f;
        public static event Action<GameState> OnGameStateChanged;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            player1.SetName("Player 1");
            player2.SetName("Player 2");
            UpdateGameState(GameState.P1Turn);
        }

        public void UpdateGameState(GameState newState)
        {
            state = newState;

            switch (newState)
            {
                case GameState.P1Turn:
                    HandleP1Turn();
                    break;
                case GameState.P2Turn:
                    HandleP2Turn();
                    break;
                case GameState.Ended:
                    HandleEnded();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }

            OnGameStateChanged?.Invoke(newState);
        }

        private void HandleP2Turn()
        {
            p1.SetActive(false);
            p2.SetActive(true);
            p2frame.SetActive(true);
            p1frame.SetActive(false);
        }

        private void HandleP1Turn()
        {
            p2.SetActive(false);
            p1.SetActive(true);
            p1frame.SetActive(true);
            p2frame.SetActive(false);
        }

        private void HandleEnded()
        {
            SavePlayerScore();
            SaveRanking();
            ScreenChanger.GameEnd();
            _turnCount = 1;
        }

        public void UpdateTurn()
        {
            _turnCount += 0.5f;
            Debug.Log($"Turn count =" + $" {_turnCount}");

            if (_turnCount.Equals(_maxTurn + 1))
            {
                UpdateGameState(GameState.Ended);
            }
        }

        public int GetTurn()
        {
            return Mathf.FloorToInt(_turnCount);
        }

        private void SavePlayerScore()
        {
            PlayerPrefs.SetString("p1", player1.GetName());
            PlayerPrefs.SetInt("p1Score", player1.GetTotalScore());
            PlayerPrefs.SetInt("p1MoneyScore", player1.GetMoneyScore());
            PlayerPrefs.SetInt("p1HealthScore", player1.GetHealthScore());
            PlayerPrefs.SetInt("p1HappyScore", player1.GetHappyScore());

            PlayerPrefs.SetString("p2", player2.GetName());
            PlayerPrefs.SetInt("p2Score", player2.GetTotalScore());
            PlayerPrefs.SetInt("p2MoneyScore", player2.GetMoneyScore());
            PlayerPrefs.SetInt("p2HealthScore", player2.GetHealthScore());
            PlayerPrefs.SetInt("p2HappyScore", player2.GetHappyScore());
        }

        private void updateScoreList()
        {
            playerList.Add(player1);
            playerList.Add(player2);
            scoreOrderedPlayerList = playerList.OrderByDescending(p => p.GetTotalScore()).ThenBy(p => p.GetHappyScore())
                .ToList();
            playerList.Clear();
        }

        private void SaveRanking()
        {
            updateScoreList();
            PlayerPrefs.SetString("1st", scoreOrderedPlayerList[0].GetName());
            PlayerPrefs.SetString("2nd", scoreOrderedPlayerList[1].GetName());
        }

        public void CheckInfection(Player player)
        {
            float infectionChance = player.GetInfectionChance();

            if (player.GetMask() > 0)
            {
                player.SetMask(-1);
                infectionChance *= 0.5f;
            }

            if (player.GetInfectionStatus())
            {
                infectionPanel.SetActive(true);
                player.SetInfectionChance(0);
                timer.DecreaseTime(timer.GetTime() * 0.2f);
                return;
            }

            bool infected = ProbabilityManager.ProbabilityCheckByPercent(Mathf.FloorToInt(infectionChance));

            player.SetInfectionStatus(infected);
            player.SetInfectionChance(0);

            if (player.GetInfectionStatus())
            {
                infectionPanel.SetActive(true);
                timer.DecreaseTime(timer.GetTime() * 0.2f);
            }
        }

        public void CheckSatiated(Player player)
        {
            if (_turnCount < 2f) return;

            if (player.GetSatiated() == 0)
            {
                hungryPanel.SetActive(true);
                return;
            }

            if (player.GetSatiated() > 100)
            {
                diarrheaPanel.SetActive(true);
                return;
            }

            player.SetSatiated(-player.GetSatiated());
        }
    }
}


public enum GameState
{
    P1Turn,
    P2Turn,
    Ended
}