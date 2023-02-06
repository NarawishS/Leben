using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrame : MonoBehaviour
{
    public GameObject statusWindow;
    public GameObject board;
    private void OnMouseDown()
    {
        statusWindow.SetActive(true);
        DODisableBoard();
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
}
