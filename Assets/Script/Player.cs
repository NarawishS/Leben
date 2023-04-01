using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class Player : MonoBehaviour
    {
        public static Player Instance { get; private set; }

        private string _name;

        // Money
        private int _wealth;

        // Deposit Money
        private int _bankMoney;

        // Healthy
        private int _health;

        // Happiness
        private int _happy;

        // Education
        private int _education;

        // Work Exp
        private int _workExp;

        // Job
        private Job _job;

        // Infection Chance
        private int _infectionChance;

        // Infection Status
        private bool _infected;

        // Mask in inventory
        private int _mask;

        // Vehicle
        private Vehicle _vehicle;

        // Current State
        private bool _walking;

        // Current Position
        private string _pos;

        public Rigidbody2D rb;

        private void Awake()
        {
            Instance = this;
            SetWealth(100_000);
            SetVehicle(Vehicle.None);
            SetJob(Job.None);
            SetWalkState(false);
            SetPosition("");
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
        public string GetPosition()
        {
            return _pos;
        }

        //Set Position
        public void SetPosition(string pos)
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
            var maxMoney = 100000;
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
    }
}