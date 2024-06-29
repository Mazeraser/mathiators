using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Assets.Codebase.UI.MainMenu
{
    public class VolumeUI : MonoBehaviour
    {
        [SerializeField]
        private AudioMixer mixer;
        [SerializeField]
        private GameObject window;
        [SerializeField]
        private Slider masterSlider;
        [SerializeField]
        private Slider sfxSlider;
        [SerializeField]
        private Slider musicSlider;

        // called at the start of the game
        // set the slider values to be the saved volume settings
        void SetSliders()
        {
            masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }

        void Start()
        {
            // do we have saved volume player prefs?
            if (PlayerPrefs.HasKey("MasterVolume"))
            {
                // set the mixer volume levels based on the saved player prefs
                mixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
                mixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
                mixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
                SetSliders();
            }
            // otherwise just set the sliders
            else
            {
                SetSliders();
            }
        }

        // called when we update the master slider
        public void UpdateMasterVolume()
        {
            mixer.SetFloat("MasterVolume", masterSlider.value);
            PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
        }
        // called when we update the sfx slider
        public void UpdateSFXVolume()
        {
            mixer.SetFloat("SFXVolume", sfxSlider.value);
            PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        }
        // called when we update the music slider
        public void UpdateMusicVolume()
        {
            mixer.SetFloat("MusicVolume", musicSlider.value);
            PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        }
    }
}