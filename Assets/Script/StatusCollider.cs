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
        var player = GameManager.Instance.GetPlayer();

        for (var i = 0; i < board.transform.childCount; i++)
        {
            var child = board.transform.GetChild(i).gameObject;
            var location = (LocationMovement)child.GetComponent(typeof(LocationMovement));
            if (!player.GetPosition().Equals(location.location)) child.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}