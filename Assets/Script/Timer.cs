using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class Timer : MonoBehaviour
    {
        private float _timeValue = 60f;
        public Text timeText;
        private float _elapsed;

        public GameObject playerEvent;

        // Update is called once per frame
        private void Update()
        {
            for (var i = 0; i < playerEvent.transform.childCount; i++)
            {
                var child = playerEvent.transform.GetChild(i).gameObject;
                if (child.activeSelf) Time.timeScale = 0;
            }

            _elapsed += Time.deltaTime;

            if (_timeValue > 0)
            {
                _timeValue -= Time.deltaTime;
            }
            else
            {
                GameManager.instance.UpdateTurn();
                
                _timeValue = 60f;

                GameManager.instance.CheckPlayerEvent(GameManager.instance.GetPlayer());
            }

            if (_elapsed >= 1f)
            {
                _elapsed %= 1f;
                timeText.color = Color.black;
            }

            DisplayTime(_timeValue);
        }

        public void DecreaseTime(float t)
        {
            timeText.color = Color.red;
            _timeValue -= t;
        }

        public float GetTime()
        {
            return _timeValue;
        }

        public void ResetTime()
        {
            _timeValue = 0;
        }

        private void DisplayTime(float timeToDisplay)
        {
            if (timeToDisplay < 0)
            {
                timeToDisplay = 0;
            }

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timeText.text = $"{minutes}:{seconds}";
        }

        public void ResumeTime()
        {
            Time.timeScale = 1f;
        }
    }
}