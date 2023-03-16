using System;
using System.Collections;
using System.Collections.Generic;
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
        private float turnCount = 1f;
        private float maxTurn = 5f;
        public static event Action<GameState> OnGameStateChanged;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
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
            ScreenChanger.GameEnd();
            turnCount = 1;
        }
        
        public void UpdateTurn()
        {
            turnCount += 0.5f;
            Debug.Log($"Turn count =" + $" {turnCount}");

            if (turnCount.Equals(maxTurn + 1))
            {
                UpdateGameState(GameState.Ended);
            }
        }

        public int GetTurn()
        {
            return  Mathf.FloorToInt(turnCount);
        }
    }
}


public enum GameState
{
    P1Turn,
    P2Turn,
    Ended
}