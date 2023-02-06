using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class LocationCollider : MonoBehaviour
    {
        public GameObject locationPanel;
        public GameObject board;

        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log($"Player Enter {gameObject.name}");
            if (locationPanel != null)
            {
                locationPanel.SetActive(true);
            }

            DODisableBoard();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log($"Player Exit {gameObject.name}");
            locationPanel.SetActive(false);
            DOEnableBoard();
        }

        public void ExitLocation()
        {
            locationPanel.SetActive(false);
            DOEnableBoard();
        }

        private void DODisableBoard()
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

        private void DOEnableBoard()
        {
            for (int i = 0; i < board.transform.childCount; i++)
            {
                GameObject child = board.transform.GetChild(i).gameObject;
                child.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}