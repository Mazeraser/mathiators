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

        [SerializeField]
        private Sprite music;
        [SerializeField]
        private Sprite music_no;
        [SerializeField]
        private Image music_icon;

        private bool has_music;

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
            has_music = true;
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
        private void Update()
        {
            music_icon.sprite = has_music ? music : music_no;
        }

        // called when we update the master slider
        public void UpdateMasterVolume()
        {
            float volume=Mathf.Lerp(0.0001f,1f,masterSlider.value/masterSlider.maxValue);
            volume=Mathf.Log10(volume)*20;

            mixer.SetFloat("MasterVolume", masterSlider.value);
            PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
        }
        // called when we update the sfx slider
        public void UpdateSFXVolume()
        {
            float volume=Mathf.Lerp(0.0001f,1f,masterSlider.value/sfxSlider.maxValue);
            volume=Mathf.Log10(volume)*20;
            
            mixer.SetFloat("SFXVolume", sfxSlider.value);
            PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        }
        // called when we update the music slider
        public void UpdateMusicVolume()
        {
            float volume=has_music ? musicSlider.value : -80;
            
            mixer.SetFloat("MusicVolume", volume);
            PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        }

        public void TurnOffMusic()
        {
            has_music = !has_music;
            UpdateMusicVolume();
        }
    }
}