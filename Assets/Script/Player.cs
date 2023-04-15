using UnityEngine;

namespace Script
{
    public class Player : MonoBehaviour
    {
        public static Player Instance { get; private set; }

        private string _name;
        private int _wealth;
        private int _bankMoney;
        private int _health;
        private int _happy;
        private int _education;
        private int _workExp;
        private Job _job;
        private int _infectionChance;
        private bool _infected;
        private int _mask;
        private Vehicle _vehicle;
        private bool _walking;
        private Location _pos;
        private int _satiated;
        private int _stamina;
        private bool _sleep;
        private int _overWork;
        private bool _cat;
        private bool _catEat;

        public Rigidbody2D rb;

        private void Awake()
        {
            Instance = this;
            _wealth = 200;
            _bankMoney = 0;
            _health = 20;
            _happy = 20;
            _education = 0;
            _workExp = 0;
            _job = Job.None;
            _infectionChance = 0;
            _infected = false;
            _mask = 0;
            _vehicle = Vehicle.None;
            _walking = false;
            _pos = Location.None;
            _satiated = 0;
            _stamina = 100;
            _overWork = 0;
            _sleep = false;
        }

        //Get money
        public int GetWealth()
        {
            return _wealth;
        }

        //Set money
        public void SetWealth(int amount)
        {
            _wealth += amount;
            if (_wealth < 0) _wealth = 0;
        }

        //Get Deposit money
        public int GetDepositMoney()
        {
            return _bankMoney;
        }

        //Set Deposit money
        public void SetDepositMoney(int amount)
        {
            _bankMoney += amount;
            if (_bankMoney < 0) _bankMoney = 0;
        }

        //Get Health
        public int GetHealth()
        {
            return _health;
        }

        //Set Health
        public void SetHealth(int amount)
        {
            _health += amount;
            if (_health < 0) _health = 0;
        }

        //Get Happiness
        public int GetHappy()
        {
            return _happy;
        }

        //Set Happiness
        public void SetHappy(int amount)
        {
            _happy += amount;
            if (_happy < 0) _happy = 0;
        }

        //Get Education
        public int GetEducation()
        {
            return _education;
        }

        //Set Education
        public void SetEducation(int amount)
        {
            _education += amount;
            if (_education > 1000) _education = 1000;
        }

        //Get Work Experience
        public int GetWorkExp()
        {
            return _workExp;
        }

        //Set Work Experience
        public void SetWorkExp(int amount)
        {
            _workExp += amount;
            if (_workExp > 1000) _workExp = 1000;
        }

        //Get Current Job
        public Job GetJob()
        {
            return _job;
        }

        //Set Current Job
        public void SetJob(Job newJob)
        {
            _job = newJob;
        }

        //Get Accumulate infection chance
        public int GetInfectionChance()
        {
            return _infectionChance;
        }

        //Set Accumulate infection chance
        public void SetInfectionChance(int amount)
        {
            _infectionChance += amount;
        }

        //Get Current Infected status
        public bool GetInfectionStatus()
        {
            return _infected;
        }

        //Set Current Infected status
        public void SetInfectionStatus(bool infection)
        {
            _infected = infection;
        }

        //Get Current mask
        public int GetMask()
        {
            return _mask;
        }

        //Set Number of mask
        public void SetMask(int amount)
        {
            _mask += amount;
        }

        //Get Vehicle
        public Vehicle GetVehicle()
        {
            return _vehicle;
        }

        //Set Vehicle
        public void SetVehicle(Vehicle newVehicle)
        {
            _vehicle = newVehicle;
        }

        //Get Position
        public Location GetPosition()
        {
            return _pos;
        }

        //Set Position
        public void SetPosition(Location pos)
        {
            _pos = pos;
        }

        //Get Current Walking State
        public bool GetWalkState()
        {
            return _walking;
        }

        //Set Current Walking State
        public void SetWalkState(bool newState)
        {
            _walking = newState;
        }

        //Get Satiated Status
        public int GetSatiated()
        {
            return _satiated;
        }

        //Set Satiated Status
        public void SetSatiated(int amount)
        {
            _satiated += amount;
        }

        //Get Stamina Status
        public int GetStamina()
        {
            return _stamina;
        }

        //Set Stamina Status
        public void SetStamina(int amount)
        {
            _stamina += amount;
        }

        // Get BurnOut
        public int GetBurnOut()
        {
            return _overWork;
        }

        // Set BurnOut
        public void SetBurnOut(int amount)
        {
            _overWork += amount;
        }

        //Get Sleep
        public bool GetSleep()
        {
            return _sleep;
        }

        //Set Sleep
        public void SetSleep(bool newState)
        {
            _sleep = newState;
        }

        public bool GetCat()
        {
            return _cat;
        }

        public void SetCat(bool cat)
        {
            _cat = cat;
        }

        public bool GetCatEat()
        {
            return _catEat;
        }

        public void SetCatEat(bool eat)
        {
            _catEat = eat;
        }

        //Get Name
        public string GetName()
        {
            return _name;
        }

        //Set Name
        public void SetName(string newName)
        {
            _name = newName;
        }

        public int GetMoneyScore()
        {
            int moneyScore;
            var maxMoney = 10000;
            if (_wealth + _bankMoney > maxMoney)
            {
                moneyScore = maxMoney;
            }
            else
            {
                moneyScore = _wealth + _bankMoney;
            }

            return moneyScore / (maxMoney / 100);
        }

        public int GetHappyScore()
        {
            int happyScore = _happy;
            var maxHappy = 1000;
            if (happyScore > maxHappy)
            {
                happyScore = maxHappy;
            }

            return happyScore / (maxHappy / 100);
        }

        public int GetHealthScore()
        {
            int healthScore = _health;
            var maxHealth = 1000;
            if (healthScore > maxHealth)
            {
                healthScore = maxHealth;
            }

            return healthScore / (maxHealth / 100);
        }

        public int GetTotalScore()
        {
            return GetMoneyScore() + GetHappyScore() + GetHealthScore();
        }

        public Location GetJobLocation()
        {
            switch (_job)
            {
                case Job.Bank:
                    return Location.Bank;
                case Job.Casino:
                    return Location.Casino;
                case Job.Hospital:
                    return Location.Hospital;
                case Job.University:
                    return Location.University;
                case Job.Gym:
                    return Location.Gym;
                case Job.Mall:
                    return Location.Mall;
                case Job.Market:
                    return Location.Market;
                case Job.Vehicle:
                    return Location.VehicleShop;
                case Job.FastFood:
                    return Location.FastFood;
                case Job.PetShop:
                    return Location.PetShop;
                case Job.None:
                    return Location.None;
                default:
                    return Location.None;
            }
        }
    }
}