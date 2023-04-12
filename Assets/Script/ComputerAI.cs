using System.Collections;
using Script;
using Script.Locations;
using UnityEngine;

namespace Script
{
    public class ComputerAI : MonoBehaviour
    {
        public GameObject body;
        public Player player;
        public GameObject board;
        public GameObject locationPanel;
        public GameObject playerEvent;
        public Timer gameTimer;
        private bool _isRunning;

        public void Update()
        {
            if (body.activeSelf && !_isRunning)
            {
                Cursor.lockState = CursorLockMode.Locked;
                _isRunning = true;
                StartCoroutine(DemoAI());
            }
            else if (!body.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Confined;
                StopAllCoroutines();
                _isRunning = false;
            }
        }

        private IEnumerator DemoAI()
        {
            yield return StartCoroutine(ClosedPlayerEvent());
            yield return StartCoroutine(MoveTo("hospital"));
            yield return StartCoroutine(MoveTo("home"));
            yield return StartCoroutine(MoveTo("university"));
            yield return StartCoroutine(MoveTo("market"));
            yield return StartCoroutine(MoveTo("home"));
            yield return StartCoroutine(EndTurn());
        }

        private IEnumerator ClosedPlayerEvent()
        {
            for (var i = playerEvent.transform.childCount - 1; i > 0; i--)
            {
                var child = playerEvent.transform.GetChild(i).gameObject;
                if (child.activeSelf)
                {
                    yield return new WaitForSecondsRealtime(2);
                    Debug.Log("Close Event");
                    child.SetActive(false);
                    gameTimer.ResumeTime();
                }
            }
        }

        private IEnumerator EndTurn()
        {
            for (var i = 0; i < locationPanel.transform.childCount; i++)
            {
                var child = locationPanel.transform.GetChild(i).gameObject;
                if (child.name.ToLower().Contains("home"))
                {
                    var home = (Home)child.GetComponent(typeof(Home));
                    yield return new WaitForSecondsRealtime(1);
                    Debug.Log("End Turn");
                    home.EndTurn();
                }
            }
        }

        private IEnumerator MoveTo(string location)
        {
            for (var i = 0; i < board.transform.childCount; i++)
            {
                var child = board.transform.GetChild(i).gameObject;
                if (child.name.Equals(location))
                {
                    var los = (LocationMovement)child.GetComponent(typeof(LocationMovement));
                    los.OnMouseUpAsButton();

                    yield return new WaitUntil(() => player.transform.position == child.transform.position);
                }
            }
        }
    }
}