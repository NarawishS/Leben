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
            var infectionChance = Random.Range(0, GameManager.Instance.GetTurn()) * 10;

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

            float v;

            switch (player.GetVehicle())
            {
                case "Bicycle":
                    v = 8f;
                    break;
                case "Motorcycle":
                    v = 11f;
                    break;
                case "Car":
                    v = 15f;
                    break;
                case "SuperCar":
                    v = 100f;
                    break;
                default:
                    v = 5;
                    break;
            }

            if (player.transform.position != gameObject.transform.position)
            {
                var s = Vector3.Distance(player.transform.position, gameObject.transform.position);
                player.transform.DOMove(transform.position, s / v).SetEase(Ease.InOutQuad);
                player.SetInfectionChance(infectionChance);
                Debug.Log($"{player.name} move to {gameObject.name}");
                // timer.DecreaseTime(2f);
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