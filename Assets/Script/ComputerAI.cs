using System;
using System.Collections;
using Script.Locations;
using UnityEngine;
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

        private PlanState _planState = PlanState.Start;

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
                _planState = PlanState.Start;
            }

            if (body.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Locked;
                if (_planState == PlanState.Start) StartCoroutine(ClosedPlayerEvent());
            }
        }

        private IEnumerator MoveTo(Location newLocation)
        {
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

        private IEnumerator ClosedPlayerEvent()
        {
            _planState = PlanState.Play;

            for (var i = playerEvent.transform.childCount - 1; i >= 0; i--)
            {
                var child = playerEvent.transform.GetChild(i).gameObject;
                if (child.activeSelf)
                {
                    yield return new WaitForSecondsRealtime(2);
                    child.SetActive(false);
                }
            }

            gameTimer.ResumeTime();

            yield return StartCoroutine(BuyMasks());
        }

        private IEnumerator BuyMasks()
        {
            if (player.GetMask() == 0)
            {
                if (!hospitalPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Hospital));

                yield return new WaitUntil(() => hospitalPanel.activeSelf);

                var hospitalScript = (Hospital)hospitalPanel.transform.GetComponent(typeof(Hospital));

                for (var i = 0; i < 5; i++)
                {
                    hospitalScript.BuyMask();
                    yield return new WaitForSeconds(1);
                }
            }

            yield return StartCoroutine(ApplyRandomJob());
        }

        private IEnumerator ApplyRandomJob()
        {
            if (player.GetJob() == Job.None)
            {
                if (!jobOfficePanel.activeSelf) yield return StartCoroutine(MoveTo(Location.JobOffice));

                yield return new WaitUntil(() => jobOfficePanel.activeSelf);

                var jobOfficeScript = (JobOffice)jobOfficePanel.transform.GetComponent(typeof(JobOffice));

                // Random Workable Job
                var jobToApply = Job.None;
                while (jobToApply == Job.None)
                {
                    var random = new Random();
                    var values = typeof(Job).GetEnumValues();
                    var index = random.Next(values.Length);
                    jobToApply = (Job)values.GetValue(index);
                }

                jobOfficeScript.ApplyJob(jobToApply);

                yield return new WaitForSeconds(1);
            }

            yield return StartCoroutine(Vaccinate());
        }

        private IEnumerator Vaccinate()
        {
            if (player.GetInfectionStatus() && player.GetWealth() >= 200)
            {
                if (!hospitalPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Hospital));

                yield return new WaitUntil(() => hospitalPanel.activeSelf);

                var hospitalScript = (Hospital)hospitalPanel.transform.GetComponent(typeof(Hospital));

                hospitalScript.BuyVaccine();

                yield return new WaitForSeconds(1);
            }

            yield return StartCoroutine(BuyCar());
        }

        private IEnumerator BuyCar()
        {
            if (player.GetWealth() >= 3000 && player.GetVehicle() == Vehicle.None)
            {
                if (!vehiclePanel.activeSelf) yield return StartCoroutine(MoveTo(Location.VehicleShop));

                yield return new WaitUntil(() => vehiclePanel.activeSelf);

                var vehicleShopScript = (VehicleShop)vehiclePanel.transform.GetComponent(typeof(VehicleShop));

                vehicleShopScript.BuyCar();

                yield return new WaitForSeconds(1);
            }

            yield return StartCoroutine(RandomAction());
        }

        private IEnumerator RandomAction()
        {
            if (player.GetWealth() >= 400)
            {
                var rnd = UnityEngine.Random.Range(1, 4);
                switch (rnd)
                {
                    case 1:
                        yield return StartCoroutine(BuyCloth());
                        break;
                    case 2:
                        yield return StartCoroutine(WeightTrain());
                        break;
                    case 3:
                        yield return StartCoroutine(ClassroomStudy());
                        break;
                }
            }
            else
            {
                yield return StartCoroutine(WorkLoop());
            }
        }

        private IEnumerator WorkLoop()
        {
            switch (player.GetJobLocation())
            {
                case Location.Bank:
                    if (!bankPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Bank));

                    yield return new WaitUntil(() => bankPanel.activeSelf);

                    var bankScript = (Bank)bankPanel.transform.GetComponent(typeof(Bank));

                    yield return new WaitForSeconds(1);

                    while (player.GetBurnOut() < 90)
                    {
                        if (gameTimer.GetTime() <= 20f) break;

                        bankScript.Work();
                        yield return new WaitForSeconds(1);
                    }

                    break;
                case Location.Casino:
                    if (!casinoPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Casino));

                    yield return new WaitUntil(() => casinoPanel.activeSelf);

                    var casinoScript = (Casino)casinoPanel.transform.GetComponent(typeof(Casino));

                    yield return new WaitForSeconds(1);

                    while (player.GetBurnOut() < 90)
                    {
                        if (gameTimer.GetTime() <= 20f) break;

                        casinoScript.Work();
                        yield return new WaitForSeconds(1);
                    }

                    break;
                case Location.Gym:
                    if (!gymPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Gym));

                    yield return new WaitUntil(() => gymPanel.activeSelf);

                    var gymScript = (Gym)gymPanel.transform.GetComponent(typeof(Gym));

                    yield return new WaitForSeconds(1);

                    while (player.GetBurnOut() < 90)
                    {
                        if (gameTimer.GetTime() <= 20f) break;

                        gymScript.Work();
                        yield return new WaitForSeconds(1);
                    }

                    break;
                case Location.Hospital:
                    if (!hospitalPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Hospital));

                    yield return new WaitUntil(() => hospitalPanel.activeSelf);

                    var hospitalScript = (Hospital)hospitalPanel.transform.GetComponent(typeof(Hospital));

                    yield return new WaitForSeconds(1);

                    while (player.GetBurnOut() < 90)
                    {
                        if (gameTimer.GetTime() <= 20f) break;

                        hospitalScript.Work();
                        yield return new WaitForSeconds(1);
                    }

                    break;
                case Location.Mall:
                    if (!mallPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Mall));

                    yield return new WaitUntil(() => mallPanel.activeSelf);

                    var mallScript = (Mall)mallPanel.transform.GetComponent(typeof(Mall));

                    yield return new WaitForSeconds(1);

                    while (player.GetBurnOut() < 90)
                    {
                        if (gameTimer.GetTime() <= 20f) break;

                        mallScript.Work();
                        yield return new WaitForSeconds(1);
                    }

                    break;
                case Location.Market:
                    if (!marketPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Market));

                    yield return new WaitUntil(() => marketPanel.activeSelf);

                    var marketScript = (Market)marketPanel.transform.GetComponent(typeof(Market));

                    yield return new WaitForSeconds(1);

                    while (player.GetBurnOut() < 90)
                    {
                        if (gameTimer.GetTime() <= 20f) break;

                        marketScript.Work();
                        yield return new WaitForSeconds(1);
                    }

                    break;
                case Location.University:
                    if (!universityPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.University));

                    yield return new WaitUntil(() => universityPanel.activeSelf);

                    var universityScript = (University)universityPanel.transform.GetComponent(typeof(University));

                    yield return new WaitForSeconds(1);

                    while (player.GetBurnOut() < 90)
                    {
                        if (gameTimer.GetTime() <= 20f) break;

                        universityScript.Work();
                        yield return new WaitForSeconds(1);
                    }

                    break;
                case Location.FastFood:
                    if (!fastFoodPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.FastFood));

                    yield return new WaitUntil(() => fastFoodPanel.activeSelf);

                    var fastFoodScript = (FastFood)fastFoodPanel.transform.GetComponent(typeof(FastFood));

                    yield return new WaitForSeconds(1);

                    while (player.GetBurnOut() < 90)
                    {
                        if (gameTimer.GetTime() <= 20f) break;

                        fastFoodScript.Work();
                        yield return new WaitForSeconds(1);
                    }

                    break;
                case Location.PetShop:
                    if (!petShopPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.PetShop));

                    yield return new WaitUntil(() => petShopPanel.activeSelf);

                    var petShopScript = (PetShop)petShopPanel.transform.GetComponent(typeof(PetShop));

                    yield return new WaitForSeconds(1);

                    while (player.GetBurnOut() < 90)
                    {
                        if (gameTimer.GetTime() <= 20f) break;

                        petShopScript.Work();
                        yield return new WaitForSeconds(1);
                    }

                    break;
                case Location.VehicleShop:
                    if (!vehiclePanel.activeSelf) yield return StartCoroutine(MoveTo(Location.VehicleShop));

                    yield return new WaitUntil(() => vehiclePanel.activeSelf);

                    var vehicleShopScript = (VehicleShop)vehiclePanel.transform.GetComponent(typeof(VehicleShop));

                    yield return new WaitForSeconds(1);

                    while (player.GetBurnOut() < 90)
                    {
                        if (gameTimer.GetTime() <= 20f) break;

                        vehicleShopScript.Work();
                        yield return new WaitForSeconds(1);
                    }

                    break;
                case Location.None:
                    break;
            }

            yield return StartCoroutine(Eat());
        }

        private IEnumerator Eat()
        {
            if (!marketPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Market));

            yield return new WaitUntil(() => marketPanel.activeSelf);

            var marketScript = (Market)marketPanel.transform.GetComponent(typeof(Market));

            marketScript.BuyFreshFood();

            _planState = PlanState.End;
            yield return new WaitForSeconds(1);
            yield return StartCoroutine(EndTurn());
        }

        private IEnumerator WeightTrain()
        {
            if (!gymPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Gym));

            yield return new WaitUntil(() => gymPanel.activeSelf);

            var gymScript = (Gym)gymPanel.transform.GetComponent(typeof(Gym));

            gymScript.DoWeightTrain();

            yield return new WaitForSeconds(1);
            yield return StartCoroutine(WorkLoop());
        }

        private IEnumerator BuyCloth()
        {
            if (!mallPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Mall));

            yield return new WaitUntil(() => mallPanel.activeSelf);

            var mallScript = (Mall)mallPanel.transform.GetComponent(typeof(Mall));

            mallScript.BuyCloth();

            yield return new WaitForSeconds(1);
            yield return StartCoroutine(WorkLoop());
        }

        private IEnumerator ClassroomStudy()
        {
            if (!universityPanel.activeSelf) yield return StartCoroutine(MoveTo(Location.University));

            yield return new WaitUntil(() => universityPanel.activeSelf);

            var universityScript = (University)universityPanel.transform.GetComponent(typeof(University));

            universityScript.Classroom();

            yield return new WaitForSeconds(1);
            yield return StartCoroutine(WorkLoop());
        }

        private IEnumerator EndTurn()
        {
            if (!homePanel.activeSelf) yield return StartCoroutine(MoveTo(Location.Home));

            yield return new WaitUntil(() => homePanel.activeSelf);

            var homeScript = (Home)homePanel.transform.GetComponent(typeof(Home));

            yield return new WaitForSeconds(1);

            homeScript.EndTurn();

            _planState = PlanState.Start;
        }

        private enum PlanState
        {
            Start,
            Play,
            End
        }
    }
}