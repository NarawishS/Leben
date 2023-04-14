using System.Collections;
using Script.Locations;
using UnityEngine;

namespace Script
{
    public class ComputerAI : MonoBehaviour
    {
        public GameObject body;
        public Player player;
        public GameObject board;
        public GameObject playerEvent;
        public Timer gameTimer;

        private State _state = State.Start;

        public GameObject bankPanel;
        public GameObject casinoPanel;
        public GameObject fastFoodPanel;
        public GameObject gymPanel;
        public GameObject homePanel;
        public GameObject hospitalPanel;
        public GameObject jobOfficePanel;
        public GameObject mallPanel;
        public GameObject marketPanel;
        public GameObject petShopPanel;
        public GameObject universityPanel;
        public GameObject vehiclePanel;

        public void Update()
        {
            if (!body.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Confined;
                StopAllCoroutines();
                _state = State.Start;
            }

            if (body.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Locked;
                switch (_state)
                {
                    case State.Start:
                        StartCoroutine(ClosedPlayerEvent());
                        _state = State.Play;
                        break;

                    case State.Play:
                        var rand = Random.Range(0, board.transform.childCount);
                        var child = board.transform.GetChild(rand);
                        var toGo = (LocationMovement)child.GetComponent(typeof(LocationMovement));
                        
                        StartCoroutine(MoveTo(toGo.location));
                        
                        // End Turn
                        if (gameTimer.GetTime() < 58f)
                        {
                            StopAllCoroutines();
                            StartCoroutine(StopMoving());
                            _state = State.End;
                        }

                        break;

                    case State.End:
                        Cursor.lockState = CursorLockMode.Locked;
                        StartCoroutine(MoveTo(Location.Home));
                        StartCoroutine(EndTurn());
                        break;
                }
            }
        }

        private IEnumerator StopMoving()
        {
            yield return new WaitUntil(() => !player.GetWalkState());
        }

        private IEnumerator ClosedPlayerEvent()
        {
            for (var i = playerEvent.transform.childCount - 1; i > 0; i--)
            {
                var child = playerEvent.transform.GetChild(i).gameObject;
                if (child.activeSelf)
                {
                    yield return new WaitForSecondsRealtime(2);
                    child.SetActive(false);
                    gameTimer.ResumeTime();
                }
            }
        }

        private IEnumerator EndTurn()
        {
            if (!homePanel.activeSelf) StartCoroutine(MoveTo(Location.Home));

            yield return new WaitUntil((() => homePanel.activeSelf));

            var homeScript = (Home)homePanel.transform.GetComponent(typeof(Home));

            yield return new WaitForSeconds(1);

            homeScript.EndTurn();
        }

        private IEnumerator MoveTo(Location newLocation)
        {
            Debug.Log($"MoveTo({newLocation})");
            for (var i = 0; i < board.transform.childCount; i++)
            {
                var child = board.transform.GetChild(i).gameObject;
                var boardLocation = (LocationMovement)child.GetComponent(typeof(LocationMovement));
                if (boardLocation.location.Equals(newLocation))
                {
                    boardLocation.OnMouseUpAsButton();
                    yield return new WaitUntil(() => player.transform.position == child.transform.position);
                }
            }
        }

        private enum Plan
        {
            Eat,
            Job,
            Entertain,
            Cure,
            End,
        }

        private enum State
        {
            Start,
            Play,
            End,
        }
    }
}