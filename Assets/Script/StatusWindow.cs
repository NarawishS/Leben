using Script;
using UnityEngine;
using UnityEngine.UI;

public class StatusWindow : MonoBehaviour
{
    public Player player;
    public Text wealthText;
    public Text healthText;
    public Text happyText;
    public Text educationText;
    public Text workexpText;
    public Text jobText;

    public Text depositText;
    public Text maskAmountText;
    public GameObject petCheckMark;
    public GameObject infectedCheckMark;
    
    private void Update()
    {
        wealthText.text = "Money: " + player.GetWealth().ToString() + " G";
        healthText.text = "Health: " + player.GetHealth().ToString();
        happyText.text = "Happiness: " + player.GetHappy().ToString();
        educationText.text = "Education: " + player.GetEducation().ToString();
        workexpText.text = "WorkExp: " + player.GetWorkExp().ToString();
        jobText.text = "Workplace: " + player.GetJob();
        
        depositText.text = " : " + player.GetDepositMoney().ToString() + " G";
        maskAmountText.text = "x " + player.GetMask().ToString();
        petCheckMark.SetActive(player.GetCat());
        infectedCheckMark.SetActive(player.GetInfectionStatus());
    }
}
