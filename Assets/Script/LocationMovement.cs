using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

namespace Script
{
    public class LocationMovement : MonoBehaviour
    {
        public GameObject locationPanel;
        public GameObject board;
        public Location location;
        public AudioSource clickSFX;
        public AudioSource actionFailSFX;
        
        public void OnMouseUpAsButton()
        {
            Player player = GameManager.Instance.GetPlayer();
            MoveTo(player);
        }

        private void MoveTo(Player player)
        {
            var infectionChance = Random.Range(0, GameManager.Instance.GetTurn()) * 3;
            if (gameObject.name.Equals("home")) infectionChance = 0;

            if (!player.GetWalkState() && !player.GetPosition().Equals(location))
            {
                clickSFX.Play();
                player.SetWalkState(true);
                player.SetPosition(location);

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
                    var playerX = player.transform.localScale.x;
                    var playerY = player.transform.localScale.y;
                    var playerZ = player.transform.localScale.z;
                    if (player.transform.position.x < gameObject.transform.position.x)
                    {
                        if (player.transform.localScale.x > 0)
                        {
                            player.transform.localScale = new Vector3(-playerX, playerY, playerZ);
                        }
                        else
                        {
                            player.transform.localScale = new Vector3(playerX, playerY, playerZ);
                        }
                    }
                    else
                    {
                        if (player.transform.localScale.x > 0)
                        {
                            player.transform.localScale = new Vector3(playerX, playerY, playerZ);
                        }
                        else
                        {
                            player.transform.localScale = new Vector3(-playerX, playerY, playerZ);
                        }
                    }

                    player.transform.DOMove(transform.position, s / v).SetEase(Ease.InOutQuad);
                    player.SetInfectionChance(infectionChance);
                    GameManager.Instance.ShowFloatingText($"{player.name} move to {location}");
                }
            }
            else if (player.GetPosition().Equals(location) &&
                     player.transform.position == gameObject.transform.position)
            {
                if (locationPanel != null)
                {
                    locationPanel.SetActive(true);
                    DoDisableBoard();
                }
            }
            else
            {
                actionFailSFX.Play();
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Player player = GameManager.Instance.GetPlayer();

            if (locationPanel != null && player.GetPosition().Equals(location))
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