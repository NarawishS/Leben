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

        public Rigidbody2D rb;

        private void Awake()
        {
            Instance = this;
            SetWealth(100_000);
            SetVehicle(Vehicle.None);
            SetJob(Job.None);
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
    }
}