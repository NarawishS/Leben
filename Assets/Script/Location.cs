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
            var infectionChance = Random.Range(0, GameManager.Instance.GetTurn()) * 50;

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
                player.transform.DOMove(transform.position, 0.2f).SetEase(Ease.InOutQuad);
                player.SetInfectionChance(infectionChance);
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
                locationPanel.SetActive(true);
            }

            DoDisableBoard();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
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
            for (var i = 0; i < board.transform.childCount; i++)
            {
                var child = board.transform.GetChild(i).gameObject;
                if (child.name != gameObject.name)
                {
                    child.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }

        private void DoEnableBoard()
        {
            for (var i = 0; i < board.transform.childCount; i++)
            {
                var child = board.transform.GetChild(i).gameObject;
                child.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}