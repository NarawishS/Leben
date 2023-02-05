using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Player : MonoBehaviour
{
    private TextMeshProUGUI goldText;
    private TextMeshProUGUI mentalText;

    private void Awake()
    {
        goldText = transform.Find("Panel").Find("goldText").GetComponent<TextMeshProUGUI>();
        mentalText = transform.Find("Panel").Find("mentalText").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        UpdateText();

        switch (GameManager.Instance.state)
        {
            case GameState.P1Turn:
                GameManager.Instance.player1.OnGoldAmountChanged += Instance_OnGoldAmountChanged;
                GameManager.Instance.player1.OnMentalAmountChanged += Instance_OnMentalAmountChanged;
                break;
            case GameState.P2Turn:
                GameManager.Instance.player2.OnGoldAmountChanged += Instance_OnGoldAmountChanged;
                GameManager.Instance.player2.OnMentalAmountChanged += Instance_OnMentalAmountChanged;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Instance_OnMentalAmountChanged(object sender, System.EventArgs e)
    {
        UpdateText();
    }

    private void Instance_OnGoldAmountChanged(object sender, System.EventArgs e)
    {
        UpdateText();
    }

    private void UpdateText()
    {
        switch (GameManager.Instance.state)
        {
            case GameState.P1Turn:
                goldText.text = GameManager.Instance.player1.GetGoldAmount().ToString();
                mentalText.text = GameManager.Instance.player1.GetMentalAmount().ToString();
                break;
            case GameState.P2Turn:
                goldText.text = GameManager.Instance.player2.GetGoldAmount().ToString();
                mentalText.text = GameManager.Instance.player2.GetMentalAmount().ToString();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}