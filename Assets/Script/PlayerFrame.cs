using Script;
using UnityEngine;

public class PlayerFrame : MonoBehaviour
{
    public GameObject statusWindow;
    public GameObject board;

    public void OpenStatus()
    {
        statusWindow.SetActive(true);
        DoDisableBoard();
    }

    private void DoDisableBoard()
    {
        Player player = GameManager.instance.GetPlayer();

        for (var i = 0; i < board.transform.childCount; i++)
        {
            var child = board.transform.GetChild(i).gameObject;
            if (player.transform.position != child.transform.position)
            {
                child.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}