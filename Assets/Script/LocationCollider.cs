using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        disbleBoard();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"Player Exit {gameObject.name}");
        locationPanel.SetActive(false);
        enableBoard();
    }

    public void ExitLocation()
    {
        locationPanel.SetActive(false);
        enableBoard();
    }

    private void disbleBoard()
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
    
    private void enableBoard()
    {
        for (int i = 0; i < board.transform.childCount; i++)
        {
            GameObject child = board.transform.GetChild(i).gameObject;
            child.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
