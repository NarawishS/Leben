using System;
using System.Collections;
using System.Linq;
using System.Threading;
using Script.Locations;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

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
        private PlanState _planState = PlanState.BuyMask;

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
                        switch (_planState)
                        {
                            case PlanState.BuyMask:
                                if (player.GetMask() == 0)
                                {
                                    StartCoroutine(MoveTo(Location.Hospital));
                                    StartCoroutine(BuyMasks());
                                }
                        
                                _planState = PlanState.ApplyJob;
                                break;
                            case PlanState.ApplyJob:
                                if (player.GetJob() == Job.None)
                                {
                                    StartCoroutine(MoveTo(Location.JobOffice));
                                    StartCoroutine(ApplyRandomJob());
                                }
                                
                                _planState = PlanState.BuyCar;
                                break;
                            case PlanState.BuyCar:
                                if (player.GetWealth() >= 3000 && player.GetVehicle() == Vehicle.None)
                                {
                                    StartCoroutine(MoveTo(Location.VehicleShop));
                                    StartCoroutine(BuyCar());
                                }
                                
                                _planState = PlanState.Vaccinate;
                                break;
                            case PlanState.Vaccinate:
                                if (player.GetInfectionStatus())
                                {
                                    StartCoroutine(MoveTo(Location.Hospital));
                                    StartCoroutine(Vaccinate());
                                }
                                
                                _planState = PlanState.WorkLoop;
                                break;
                            case PlanState.WorkLoop:
                                StartCoroutine(MoveTo(player.GetJobLocation()));
                                StartCoroutine(WorkLoop());
                                
                                _planState = PlanState.Eat;
                                break;
                        }

                        // StartCoroutine(PlayPlan());

                        if (gameTimer.GetTime() < 15f)
                        {
                            StopAllCoroutines();
                            StartCoroutine(StopMoving());
                            _state = State.End;
                        }
                        
                        break;

                    case State.End:
                        Cursor.lockState = CursorLockMode.Locked;

                        switch (_planState)
                        {
                            case PlanState.Eat:
                                if (player.GetSatiated() == 0)
                                {
                                    StartCoroutine(MoveTo(Location.Market));
                                    StartCoroutine(Eat());
                                }
                                
                                _planState = PlanState.Sleep;
                                break;
                            case PlanState.Sleep:
                                StartCoroutine(MoveTo(Location.Home));
                                StartCoroutine(EndTurn());
                                
                                break;
                        }

                        // StartCoroutine(EndPlan());
                        break;
                }
            }
        }

        public IEnumerator PlayPlan()
        {
            if (player.GetMask() == 0)
            {
                yield return StartCoroutine(MoveTo(Location.Hospital));
                yield return StartCoroutine(BuyMasks());
            }
            
            if (player.GetJob() == Job.None)
            {
                yield return StartCoroutine(MoveTo(Location.JobOffice));
                yield return StartCoroutine(ApplyRandomJob());
            }

            if (player.GetWealth() >= 3000 && player.GetVehicle() == Vehicle.None)
            {
                yield return StartCoroutine(MoveTo(Location.VehicleShop));
                yield return StartCoroutine(BuyCar());
            }
            
            if (player.GetInfectionStatus())
            {
                yield return StartCoroutine(MoveTo(Location.Hospital));
                yield return StartCoroutine(Vaccinate());
            }
            
            yield return StartCoroutine(MoveTo(player.GetJobLocation()));
            yield return StartCoroutine(WorkLoop());
        }

        public IEnumerator EndPlan()
        {
            if (player.GetSatiated() == 0)
            {
                yield return StartCoroutine(MoveTo(Location.Market));
                yield return StartCoroutine(Eat());
            }
            
            yield return StartCoroutine(MoveTo(Location.Home));
            yield return StartCoroutine(EndTurn());
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
            if (!homePanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Home));

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

        private IEnumerator BuyMasks()
        {
            if (!hospitalPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Hospital));

            yield return new WaitUntil((() => hospitalPanel.activeSelf));

            var hospitalScript = (Hospital)hospitalPanel.transform.GetComponent(typeof(Hospital));

            for (var i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(1);
                hospitalScript.BuyMask();
            }
        }

        private IEnumerator ApplyRandomJob()
        {
            if (!jobOfficePanel.activeSelf) yield return StartCoroutine(MoveTo(Location.JobOffice));

            yield return new WaitUntil((() => jobOfficePanel.activeSelf));

            var jobOfficeScript = (JobOffice)jobOfficePanel.transform.GetComponent(typeof(JobOffice));

            yield return new WaitForSeconds(1);
            
            // Random Workable Job
            Job jobToApply = Job.None;
            while (jobToApply == Job.None)
            {
                Random random = new Random();
                Array values = typeof(Job).GetEnumValues();
                int index = random.Next(values.Length);
                jobToApply = (Job)values.GetValue(index);
            }

            jobOfficeScript.ApplyJob(jobToApply);
        }

        private IEnumerator BuyCar()
        {
            if (!vehiclePanel.activeSelf) yield return StartCoroutine(MoveTo(Location.VehicleShop));

            yield return new WaitUntil((() => vehiclePanel.activeSelf));

            var vehicleShopScript = (VehicleShop)vehiclePanel.transform.GetComponent(typeof(VehicleShop));

            yield return new WaitForSeconds(1);
            
            vehicleShopScript.BuyCar();
        }
        
        private IEnumerator Vaccinate()
        {
            if (!hospitalPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Hospital));

            yield return new WaitUntil((() => hospitalPanel.activeSelf));

            var hospitalScript = (Hospital)hospitalPanel.transform.GetComponent(typeof(Hospital));

            yield return new WaitForSeconds(1);
            
            hospitalScript.BuyVaccine();
        }
        
        private IEnumerator Eat()
        {
            if (!marketPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Market));

            yield return new WaitUntil((() => marketPanel.activeSelf));

            var marketScript = (Market)marketPanel.transform.GetComponent(typeof(Market));

            yield return new WaitForSeconds(1);
            
            marketScript.BuyFreshFood();
        }
        
        private IEnumerator WorkLoop()
        {
            switch (player.GetJobLocation())
            {
                case Location.Bank:
                    if (!bankPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Bank));

                    yield return new WaitUntil((() => bankPanel.activeSelf));

                    var bankScript = (Bank)bankPanel.transform.GetComponent(typeof(Bank));

                    yield return new WaitForSeconds(1);

                    while (gameTimer.GetTime() > 15f)
                    {
                        bankScript.Work();
                        yield return new WaitForSeconds(1);
                    }
                    break;
                case Location.Casino:
                    if (!casinoPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Casino));

                    yield return new WaitUntil((() => casinoPanel.activeSelf));

                    var casinoScript = (Casino)casinoPanel.transform.GetComponent(typeof(Casino));

                    yield return new WaitForSeconds(1);

                    while (_state == State.Play)
                    {
                        casinoScript.Work();
                        yield return new WaitForSeconds(1);
                    }
                    break;
                case Location.Gym:
                    if (!gymPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Gym));

                    yield return new WaitUntil((() => gymPanel.activeSelf));

                    var gymScript = (Gym)gymPanel.transform.GetComponent(typeof(Gym));

                    yield return new WaitForSeconds(1);

                    while (gameTimer.GetTime() > 15f)
                    {
                        gymScript.Work();
                        yield return new WaitForSeconds(1);
                    }
                    break;
                case Location.Hospital:
                    if (!hospitalPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Hospital));

                    yield return new WaitUntil((() => hospitalPanel.activeSelf));

                    var hospitalScript = (Hospital)hospitalPanel.transform.GetComponent(typeof(Hospital));

                    yield return new WaitForSeconds(1);

                    while (gameTimer.GetTime() > 15f)
                    {
                        hospitalScript.Work();
                        yield return new WaitForSeconds(1);
                    }
                    break;
                case Location.Mall:
                    if (!mallPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Mall));

                    yield return new WaitUntil((() => mallPanel.activeSelf));

                    var mallScript = (Mall)mallPanel.transform.GetComponent(typeof(Mall));

                    yield return new WaitForSeconds(1);

                    while (gameTimer.GetTime() > 15f)
                    {
                        mallScript.Work();
                        yield return new WaitForSeconds(1);
                    }
                    break;
                case Location.Market:
                    if (!marketPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Market));

                    yield return new WaitUntil((() => marketPanel.activeSelf));

                    var marketScript = (Market)marketPanel.transform.GetComponent(typeof(Market));

                    yield return new WaitForSeconds(1);

                    while (gameTimer.GetTime() > 15f)
                    {
                        marketScript.Work();
                        yield return new WaitForSeconds(1);
                    }
                    break;
                case Location.University:
                    if (!universityPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.University));

                    yield return new WaitUntil((() => universityPanel.activeSelf));

                    var universityScript = (University)universityPanel.transform.GetComponent(typeof(University));

                    yield return new WaitForSeconds(1);

                    while (gameTimer.GetTime() > 15f)
                    {
                        universityScript.Work();
                        yield return new WaitForSeconds(1);
                    }
                    break;
                case Location.FastFood:
                    if (!fastFoodPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.FastFood));

                    yield return new WaitUntil((() => fastFoodPanel.activeSelf));

                    var fastFoodScript = (FastFood)fastFoodPanel.transform.GetComponent(typeof(FastFood));

                    yield return new WaitForSeconds(1);

                    while (gameTimer.GetTime() > 15f)
                    {
                        fastFoodScript.Work();
                        yield return new WaitForSeconds(1);
                    }
                    break;
                case Location.PetShop:
                    if (!petShopPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.PetShop));

                    yield return new WaitUntil((() => petShopPanel.activeSelf));

                    var petShopScript = (PetShop)petShopPanel.transform.GetComponent(typeof(PetShop));

                    yield return new WaitForSeconds(1);

                    while (gameTimer.GetTime() > 15f)
                    {
                        petShopScript.Work();
                        yield return new WaitForSeconds(1);
                    }
                    break;
                case Location.VehicleShop:
                    if (!vehiclePanel.activeSelf) yield return StartCoroutine(MoveTo(Location.VehicleShop));

                    yield return new WaitUntil((() => vehiclePanel.activeSelf));

                    var vehicleShopScript = (VehicleShop)vehiclePanel.transform.GetComponent(typeof(VehicleShop));

                    yield return new WaitForSeconds(1);

                    while (gameTimer.GetTime() > 15f)
                    {
                        vehicleShopScript.Work();
                        yield return new WaitForSeconds(1);
                    }
                    break;
                case Location.None:
                    break;
            }
        }

        private enum State
        {
            Start,
            Play,
            End,
        }
        
        private enum PlanState
        {
            BuyMask,
            ApplyJob,
            BuyCar,
            Vaccinate,
            WorkLoop,
            Eat,
            Sleep
        }
    }
}