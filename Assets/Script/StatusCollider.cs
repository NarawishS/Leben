using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusCollider : MonoBehaviour
{
    public GameObject statusWindow;
    public GameObject board;

    public void ExitPanel()
    {
        statusWindow.SetActive(false);
        DOEnableBoard();
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
