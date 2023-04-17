using Script;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    public Text p1Rank;
    public Text p1MoneyScore;
    public Text p1HealthScore;
    public Text p1HappyScore;
    public Text p1TotalScore;

    public Text p2Rank;
    public Text p2MoneyScore;
    public Text p2HealthScore;
    public Text p2HappyScore;
    public Text p2TotalScore;

    public Text p3Rank;
    public Text p3MoneyScore;
    public Text p3HealthScore;
    public Text p3HappyScore;
    public Text p3TotalScore;

    public Text p4Rank;
    public Text p4MoneyScore;
    public Text p4HealthScore;
    public Text p4HappyScore;
    public Text p4TotalScore;

    public Text vsBotResult;
    public Text botMoneyScore;
    public Text botHealthScore;
    public Text botHappyScore;
    public Text botTotalScore;

    public GameObject vsPlayerScreen;
    public GameObject vsBotScreen;

    private void Start()
    {
        if (GameManager.Training)
        {
            HandleVsBot();
            vsPlayerScreen.SetActive(false);
            vsBotScreen.SetActive(true);
        }
        else
        {
            HandleVsPlayer();
            vsBotScreen.SetActive(false);
            vsPlayerScreen.SetActive(true);
        }
    }

    public void HandleVsBot()
    {
        p1MoneyScore.text = "Money Score: " + PlayerPrefs.GetInt("p1MoneyScore").ToString();
        botMoneyScore.text = "Money Score: " + PlayerPrefs.GetInt("botMoneyScore").ToString();

        p1HealthScore.text = "Health Score: " + PlayerPrefs.GetInt("p1HealthScore").ToString();
        botHealthScore.text = "Health Score: " + PlayerPrefs.GetInt("botHealthScore").ToString();

        p1HappyScore.text = "Happiness Score: " + PlayerPrefs.GetInt("p1HappyScore").ToString();
        botHappyScore.text = "Happiness Score: " + PlayerPrefs.GetInt("botHappyScore").ToString();

        p1TotalScore.text = "Total Score: " + PlayerPrefs.GetInt("p1Score").ToString();
        botTotalScore.text = "Total Score: " + PlayerPrefs.GetInt("botScore").ToString();

        if (PlayerPrefs.GetInt("p1Score") == PlayerPrefs.GetInt("botScore"))
            vsBotResult.text = "Draw!";
        else if (PlayerPrefs.GetInt("p1Score") > PlayerPrefs.GetInt("botScore"))
            vsBotResult.text = "Player Win!";
        else
            vsBotResult.text = "Bot Win!";
    }

    public void HandleVsPlayer()
    {
        p1MoneyScore.text = "Money Score: " + PlayerPrefs.GetInt("p1MoneyScore").ToString();
        p2MoneyScore.text = "Money Score: " + PlayerPrefs.GetInt("p2MoneyScore").ToString();
        p3MoneyScore.text = "Money Score: " + PlayerPrefs.GetInt("p3MoneyScore").ToString();
        p4MoneyScore.text = "Money Score: " + PlayerPrefs.GetInt("p4MoneyScore").ToString();

        p1HealthScore.text = "Health Score: " + PlayerPrefs.GetInt("p1HealthScore").ToString();
        p2HealthScore.text = "Health Score: " + PlayerPrefs.GetInt("p2HealthScore").ToString();
        p3HealthScore.text = "Health Score: " + PlayerPrefs.GetInt("p3HealthScore").ToString();
        p4HealthScore.text = "Health Score: " + PlayerPrefs.GetInt("p4HealthScore").ToString();

        p1HappyScore.text = "Happiness Score: " + PlayerPrefs.GetInt("p1HappyScore").ToString();
        p2HappyScore.text = "Happiness Score: " + PlayerPrefs.GetInt("p2HappyScore").ToString();
        p3HappyScore.text = "Happiness Score: " + PlayerPrefs.GetInt("p3HappyScore").ToString();
        p4HappyScore.text = "Happiness Score: " + PlayerPrefs.GetInt("p4HappyScore").ToString();

        p1TotalScore.text = "Total Score: " + PlayerPrefs.GetInt("p1Score").ToString();
        p2TotalScore.text = "Total Score: " + PlayerPrefs.GetInt("p2Score").ToString();
        p3TotalScore.text = "Total Score: " + PlayerPrefs.GetInt("p3Score").ToString();
        p4TotalScore.text = "Total Score: " + PlayerPrefs.GetInt("p4Score").ToString();

        switch (PlayerPrefs.GetString("1st"))
        {
            case "Player 1":
                p1Rank.text = "1st";
                break;
            case "Player 2":
                p2Rank.text = "1st";
                break;
            case "Player 3":
                p3Rank.text = "1st";
                break;
            case "Player 4":
                p4Rank.text = "1st";
                break;
        }

        switch (PlayerPrefs.GetString("2nd"))
        {
            case "Player 1":
                p1Rank.text = "2nd";
                break;
            case "Player 2":
                p2Rank.text = "2nd";
                break;
            case "Player 3":
                p3Rank.text = "2nd";
                break;
            case "Player 4":
                p4Rank.text = "2nd";
                break;
        }

        switch (PlayerPrefs.GetString("3rd"))
        {
            case "Player 1":
                p1Rank.text = "3rd";
                break;
            case "Player 2":
                p2Rank.text = "3rd";
                break;
            case "Player 3":
                p3Rank.text = "3rd";
                break;
            case "Player 4":
                p4Rank.text = "3rd";
                break;
        }

        switch (PlayerPrefs.GetString("4th"))
        {
            case "Player 1":
                p1Rank.text = "4th";
                break;
            case "Player 2":
                p2Rank.text = "4th";
                break;
            case "Player 3":
                p3Rank.text = "4th";
                break;
            case "Player 4":
                p4Rank.text = "4th";
                break;
        }
    }
}