using System;
using UnityEngine;
using DG.Tweening;
using UnityEditor;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Script
{
    public class Location : MonoBehaviour
    {
        public Timer timer;
        public GameObject locationPanel;
        public GameObject board;
        private string _currentLocation;

        private void OnMouseDown()
        {
            _currentLocation = gameObject.name;
            Player player;
            int infectionChance = Random.Range(0, GameManager.Instance.GetTurn());
            Debug.Log($"Infection rate = {infectionChance}%");
            switch (GameManager.Instance.state)
            {
                case GameState.P1Turn:
                    player = GameManager.Instance.player1;
                    break;
                case GameState.P2Turn:
                    player = GameManager.Instance.player2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (player.transform.position != gameObject.transform.position)
            {
                player.transform.DOMove(transform.position, 0.5f).SetEase(Ease.InOutQuad);
                Debug.Log($"{player.name} move to {gameObject.name}");
                timer.DecreaseTime(2);
            }
            else
            {
                if (locationPanel != null)
                {
                    locationPanel.SetActive(true);
                }
                DoDisableBoard();
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (locationPanel != null && _currentLocation == gameObject.name)
            {
                Debug.Log($"Player Enter {gameObject.name}");
                locationPanel.SetActive(true);
            }

            DoDisableBoard();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (_currentLocation == gameObject.name)
            {
                Debug.Log($"Player Exit {gameObject.name}");
            }

            locationPanel.SetActive(false);
            DoEnableBoard();
        }

        public void ExitLocation()
        {
            locationPanel.SetActive(false);
            DoEnableBoard();
        }

        private void DoDisableBoard()
        {
            for (int i = 0; i < board.transform.childCount; i++)
            {
                GameObject child = board.transform.GetChild(i).gameObject;
                if (child.name != gameObject.name)
                {
                    child.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }

        private void DoEnableBoard()
        {
            for (int i = 0; i < board.transform.childCount; i++)
            {
                GameObject child = board.transform.GetChild(i).gameObject;
                child.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}