using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timeValue = 120;
    public Text timeText;
    
    public float elapsed = 0f;
    
    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            switch (GameManager.Instance.state)
            {
                case GameState.P1Turn:
                    GameManager.Instance.UpdateGameState(GameState.P2Turn);
                    break;
                case GameState.P2Turn:
                    GameManager.Instance.UpdateGameState(GameState.P1Turn);
                    break;
            }
            timeValue = 120;
        }
        
        if (elapsed >= 1f) {
            elapsed = elapsed % 1f;
            GetComponent<Text>().color = Color.black;
        }
        
        DisplayTime(timeValue);
    }

    public void DecreaseTime(int t)
    {
        GetComponent<Text>().color = Color.red;
        timeValue -= t;
        
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
