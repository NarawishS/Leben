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

    private void Update()
    {
        wealthText.text = "Money: " + player.GetWealth().ToString();
        healthText.text = "Health: " + player.GetHealth().ToString();
        happyText.text = "Happiness: " + player.GetHappy().ToString();
        educationText.text = "Education: " + player.GetEducation().ToString();
        workexpText.text = "WorkExp: " + player.GetWorkExp().ToString();
        jobText.text = "Workplace: " + player.GetJob();
    }
}
