using System.Collections;
using System.Collections.Generic;
using Script;
using Script.Locations;
using UnityEngine;

public class ComputerAI : MonoBehaviour
{
    public GameObject body;
    public Player player;
    public GameObject board;
    public GameObject panel;

    // Update is called once per frame
    public void Update()
    {
        if (body.activeSelf && !player.GetWalkState())
        {
            MoveTo("hospital");
        }
    }

    private void EndTurn()
    {
        MoveTo("home");
        for (var i = 0; i < panel.transform.childCount; i++)
        {
            var child = panel.transform.GetChild(i).gameObject;
            if (child.name.ToLower().Contains("home"))
            {
                Debug.Log("home");
                var home = (Home)child.GetComponent(typeof(Home));
                home.EndTurn();
            }
        }
    }

    private void MoveTo(string location)
    {
        for (var i = 0; i < board.transform.childCount; i++)
        {
            var child = board.transform.GetChild(i).gameObject;
            if (child.name.Equals(location))
            {
                var los = (Location)child.GetComponent(typeof(Location));
                los.OnMouseUpAsButton();
                return;
            }
        }
    }
}