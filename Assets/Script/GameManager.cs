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
        public Player player1;
        public Player player2;
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
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }

            OnGameStateChanged?.Invoke(newState);
        }

        private void HandleP2Turn()
        {
            p1.SetActive(false);
            p2.SetActive(true);
        }

        private void HandleP1Turn()
        {
            p2.SetActive(false);
            p1.SetActive(true);
        }
    }
}


public enum GameState
{
    P1Turn,
    P2Turn
}