using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Script
{
    public class VolumeSetting : MonoBehaviour
    {
        [SerializeField] private AudioMixer myMixer;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;
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
                SetSFXVolume();
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
            var volume = musicSlider.value;
            myMixer.SetFloat("musicVolume", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("musicVolume", volume);
        }

        public void SetSFXVolume()
        {
            var volume = sfxSlider.value;
            myMixer.SetFloat("sfxVolume", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("sfxVolume", volume);
        }

        private void LoadVolume()
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");

            SetMusicVolume();
            SetSFXVolume();
        }
    }
}