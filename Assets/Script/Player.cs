using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IShopCustomer
{
    public static Player Instance { get; private set; }
    public event EventHandler OnGoldAmountChanged;
    private int goldAmount;
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool moving;

    private void Awake()
    {
        Instance = this;
    }

    public void AddGoldAmount(int addGoldAmount)
    {
        goldAmount += addGoldAmount;
        OnGoldAmountChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetGoldAmount()
    {
        return goldAmount;
    }

    public void BoughtItem(Action.ActionType actionType)
    {
        Debug.Log("Do action: " + actionType);
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

    private void Update()
    {
        
    }

    private void mouseMovement()
    {
        
    }
}