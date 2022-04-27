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

        Player.Instance.OnGoldAmountChanged += Instance_OnGoldAmountChanged;
        Player.Instance.OnMentalAmountChanged += Instance_OnMentalAmountChanged;
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
        goldText.text = Player.Instance.GetGoldAmount().ToString();
        mentalText.text = Player.Instance.GetMentalAmount().ToString();
    }
}