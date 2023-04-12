using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Script
{
    public class VolumeSetting : MonoBehaviour
    {
        [SerializeField] private AudioMixer myMixer;
        [SerializeField] private Slider musicSlider;
        public GameObject optionPanel;

        private void Start()
        {
            if (PlayerPrefs.HasKey("musicVolume"))
            {
                LoadVolume();
            }
            else
            {
                SetMusicVolume();
            }
        }

        public void TogglePanel()
        {
            optionPanel.SetActive(true);
        }

        public void ClosePanel()
        {
            optionPanel.SetActive(false);
        }

        public void SetMusicVolume()
        {
            float volume = musicSlider.value;
            myMixer.SetFloat("musicVolume", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("musicVolume", volume);
        }

        private void LoadVolume()
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");

            SetMusicVolume();
        }
    }
}