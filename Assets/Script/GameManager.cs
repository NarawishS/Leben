using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Serialization;

namespace Script
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public GameState state;
        public GameObject p1;
        public GameObject p2;
        public GameObject p3;
        public GameObject p4;
        public GameObject p1frame;
        public GameObject p2frame;
        public GameObject p3frame;
        public GameObject p4frame;
        public Player player1;
        public Player player2;
        public Player player3;
        public Player player4;
        public List<Player> playerList;
        public List<Player> scoreOrderedPlayerList;
        public AudioSource bgm;
        public AudioClip lastTurnBGM;

        public GameObject loadPanel;

        public Timer timer;
        public Text turnText;
        public GameObject board;

        public GameObject turnPanel;
        public Text turnPanelText;

        public GameObject infectionPanel;
        public GameObject hungryPanel;
        public GameObject diarrheaPanel;
        public GameObject robPanel;
        public GameObject sleepPanel;
        public GameObject musclePanel;
        public GameObject burnOutPanel;

        private float _turnCount = 1f;
        private const float MaxTurn = 2f;
        public static event Action<GameState> OnGameStateChanged;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            player1.SetName("Player 1");
            player2.SetName("Player 2");
            player3.SetName("Player 3");
            player4.SetName("Player 4");
            UpdateGameState(GameState.P1Turn);
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
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
                case GameState.P3Turn:
                    HandleP3Turn();
                    break;
                case GameState.P4Turn:
                    HandleP4Turn();
                    break;
                case GameState.Ended:
                    HandleEnded();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }

            OnGameStateChanged?.Invoke(newState);
        }

        private void HandleP4Turn()
        {
            p1.SetActive(false);
            p2.SetActive(false);
            p3.SetActive(false);
            p4.SetActive(true);
            p1frame.SetActive(false);
            p2frame.SetActive(false);
            p3frame.SetActive(false);
            p4frame.SetActive(true);
            StartTurnText($"{player4.GetName()} turn");
        }

        private void HandleP3Turn()
        {
            p1.SetActive(false);
            p2.SetActive(false);
            p3.SetActive(true);
            p4.SetActive(false);
            p1frame.SetActive(false);
            p2frame.SetActive(false);
            p3frame.SetActive(true);
            p4frame.SetActive(false);
            StartTurnText($"{player3.GetName()} turn");
        }

        private void HandleP2Turn()
        {
            p1.SetActive(false);
            p2.SetActive(true);
            p3.SetActive(false);
            p4.SetActive(false);
            p1frame.SetActive(false);
            p2frame.SetActive(true);
            p3frame.SetActive(false);
            p4frame.SetActive(false);
            StartTurnText($"{player2.GetName()} turn");
        }

        private void HandleP1Turn()
        {
            p1.SetActive(true);
            p2.SetActive(false);
            p3.SetActive(false);
            p4.SetActive(false);
            p1frame.SetActive(true);
            p2frame.SetActive(false);
            p3frame.SetActive(false);
            p4frame.SetActive(false);
            StartTurnText($"{player1.GetName()} turn");
        }

        private async void HandleEnded()
        {
            var scene = SceneManager.LoadSceneAsync("Scenes/EndGame");
            scene.allowSceneActivation = false;
            loadPanel.SetActive(true);
            SavePlayerScore();
            SaveRanking();
            _turnCount = 1;
            do
            {
                await Task.Delay(100);
            } while (scene.progress < 0.9f);

            scene.allowSceneActivation = true;
        }

        private void StartTurnText(string text)
        {
            turnPanel.SetActive(true);
            turnPanelText.text = text;
        }

        public void UpdateTurn()
        {
            _turnCount += 0.25f;
            turnText.text = $"Turn {Mathf.FloorToInt(_turnCount)}";

            if (_turnCount.Equals(MaxTurn + 1))
            {
                UpdateGameState(GameState.Ended);
            }

            if (_turnCount.Equals(MaxTurn))
            {
                bgm.clip = lastTurnBGM;
                bgm.Play();
            }
        }

        public int GetTurn()
        {
            return Mathf.FloorToInt(_turnCount);
        }

        public int GetLastTurn()
        {
            return Mathf.FloorToInt(MaxTurn);
        }

        public Player GetPlayer()
        {
            switch (state)
            {
                case GameState.P1Turn:
                    return player1;
                case GameState.P2Turn:
                    return player2;
                case GameState.P3Turn:
                    return player3;
                case GameState.P4Turn:
                    return player4;
                default:
                    return player1;
            }
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

            PlayerPrefs.SetString("p3", player3.GetName());
            PlayerPrefs.SetInt("p3Score", player3.GetTotalScore());
            PlayerPrefs.SetInt("p3MoneyScore", player3.GetMoneyScore());
            PlayerPrefs.SetInt("p3HealthScore", player3.GetHealthScore());
            PlayerPrefs.SetInt("p3HappyScore", player3.GetHappyScore());

            PlayerPrefs.SetString("p4", player4.GetName());
            PlayerPrefs.SetInt("p4Score", player4.GetTotalScore());
            PlayerPrefs.SetInt("p4MoneyScore", player4.GetMoneyScore());
            PlayerPrefs.SetInt("p4HealthScore", player4.GetHealthScore());
            PlayerPrefs.SetInt("p4HappyScore", player4.GetHappyScore());
        }

        private void UpdateScoreList()
        {
            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            playerList.Add(player4);
            scoreOrderedPlayerList = playerList.OrderByDescending(p => p.GetTotalScore()).ThenBy(p => p.GetHappyScore())
                .ToList();
            playerList.Clear();
        }

        private void SaveRanking()
        {
            UpdateScoreList();
            PlayerPrefs.SetString("1st", scoreOrderedPlayerList[0].GetName());
            PlayerPrefs.SetString("2nd", scoreOrderedPlayerList[1].GetName());
            PlayerPrefs.SetString("3rd", scoreOrderedPlayerList[2].GetName());
            PlayerPrefs.SetString("4th", scoreOrderedPlayerList[3].GetName());
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
            }
            else if (player.GetSatiated() > 100)
            {
                diarrheaPanel.SetActive(true);
            }

            player.SetSatiated(-player.GetSatiated());
        }

        public void CheckRobbed(Player player)
        {
            if (_turnCount < 2f) return;

            if (ProbabilityManager.ProbabilityCheckByPercent(25))
            {
                var amount = Mathf.FloorToInt(player.GetWealth() * 0.25f);
                player.SetWealth(-amount);
                robPanel.SetActive(true);
            }
        }

        public void CheckSleep(Player player)
        {
            if (_turnCount < 2f) return;

            if (!player.GetSleep())
            {
                sleepPanel.SetActive(true);
                timer.DecreaseTime(timer.GetTime() * 0.2f);
            }

            player.SetSleep(false);
        }

        public void CheckStamina(Player player)
        {
            if (_turnCount < 2f) return;

            if (player.GetStamina() <= 0)
            {
                musclePanel.SetActive(true);
                player.SetHealth(-Mathf.FloorToInt(player.GetHealth() * 0.2f));
            }

            player.SetStamina(-player.GetStamina());
            player.SetStamina(+100);
        }

        public void CheckStress(Player player)
        {
            if (_turnCount < 2f) return;
        }

        public void CheckBurnOut(Player player)
        {
            if (_turnCount < 2f) return;

            if (player.GetBurnOut() >= 100)
            {
                burnOutPanel.SetActive(true);
                player.SetHealth(-Mathf.FloorToInt(player.GetHealth() * 0.2f));
                player.SetHappy(-Mathf.FloorToInt(player.GetHappy() * 0.2f));
            }

            player.SetBurnOut(-player.GetBurnOut());
        }
    }
}


public enum GameState
{
    P1Turn,
    P2Turn,
    P3Turn,
    P4Turn,
    Ended
}