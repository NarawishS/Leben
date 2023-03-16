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
