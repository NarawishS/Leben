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

        // Healthy
        private int _health;

        // Happiness
        private int _happy;

        // Education
        private int _education;

        // Work Exp
        private int _workExp;

        // Job
        private string _job;

        public Rigidbody2D rb;

        private void Awake()
        {
            Instance = this;
            SetWealth(500);
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

        public string GetJob()
        {
            return _job;
        }

        public void SetJob(string newJob)
        {
            _job = newJob;
        }
    }
}