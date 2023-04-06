using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class StatusCollider : MonoBehaviour
{
    public GameObject statusWindow;
    public GameObject board;

    public void ExitPanel()
    {
        statusWindow.SetActive(false);
        DoEnableBoard();
    }

    private void DoEnableBoard()
    {
        Player player = GameManager.Instance.GetPlayer();

        for (var i = 0; i < board.transform.childCount; i++)
        {
            var child = board.transform.GetChild(i).gameObject;
            if (player.transform.position != child.transform.position)
            {
                child.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}
