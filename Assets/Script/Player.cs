using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IShopCustomer
{
    public static Player Instance { get; private set; }
    public event EventHandler OnGoldAmountChanged;
    public event EventHandler OnMentalAmountChanged;
    private int goldAmount;
    private int mentalAmount;
    public Rigidbody2D rb;

    private void Awake()
    {
        Instance = this;
        goldAmount += 100;
    }

    public void AddGoldAmount(int addGoldAmount)
    {
        goldAmount += addGoldAmount;
        OnGoldAmountChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log($"gold: {goldAmount}");
    }

    public void AddMentalAmount(int addMentalAmount)
    {
        mentalAmount += addMentalAmount;
        if (mentalAmount > 2500) mentalAmount = 2500;
        OnMentalAmountChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log($"mental: {mentalAmount}");
    }

    public int GetGoldAmount()
    {
        return goldAmount;
    }

    public int GetMentalAmount()
    {
        return mentalAmount;
    }

    public void ParkBench()
    {
        AddMentalAmount(10);
    }

    public void DoJob()
    {
        AddGoldAmount(100);
        AddMentalAmount(-1);
    }

    public void BoughtItem(Action.ActionType actionType)
    {
        Debug.Log("Do action: " + actionType);
        switch (actionType)
        {
            case Action.ActionType.Slider:

                break;
            case Action.ActionType.Bench:
                ParkBench();
                break;
            case Action.ActionType.Work:
                DoJob();
                break;
        }
    }

    public bool TrySpendGoldAmount(int spendGoldAmount)
    {
        if (GetGoldAmount() >= spendGoldAmount)
        {
            goldAmount -= spendGoldAmount;
            OnGoldAmountChanged?.Invoke(this, EventArgs.Empty);
            return true;
        }
        else
        {
            return false;
        }
    }
}