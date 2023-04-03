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
        public GameObject locationPanel;
        public GameObject board;

        private void OnMouseUpAsButton()
        {
            Player player;
            var infectionChance = Random.Range(0, GameManager.Instance.GetTurn()) * 3;

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

            if (!player.GetWalkState() && !player.GetPosition().Equals(gameObject.name))
            {
                player.SetWalkState(true);
                player.SetPosition(gameObject.name);

                float v;

                switch (player.GetVehicle())
                {
                    case Vehicle.Bicycle:
                        v = 6f;
                        break;
                    case Vehicle.Motorcycle:
                        v = 12f;
                        break;
                    case Vehicle.Car:
                        v = 17f;
                        break;
                    case Vehicle.SuperCar:
                        v = 100f;
                        break;
                    case Vehicle.None:
                        v = 3;
                        break;
                    default:
                        v = 3;
                        break;
                }

                if (player.transform.position != gameObject.transform.position)
                {
                    var s = Vector2.Distance(player.transform.position, gameObject.transform.position);
                    player.transform.DOMove(transform.position, s / v).SetEase(Ease.InOutQuad);
                    player.SetInfectionChance(infectionChance);
                    Debug.Log($"{player.name} move to {gameObject.name}");
                }
            }
            else if (player.GetPosition().Equals(gameObject.name) &&
                     player.transform.position == gameObject.transform.position)
            {
                if (locationPanel != null)
                {
                    locationPanel.SetActive(true);
                    DoDisableBoard();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
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
                    throw new ArgumentOutOfRangeException();
            }

            if (locationPanel != null && player.GetPosition().Equals(gameObject.name))
            {
                player.SetWalkState(false);
                locationPanel.SetActive(true);
                DoDisableBoard();
            }
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