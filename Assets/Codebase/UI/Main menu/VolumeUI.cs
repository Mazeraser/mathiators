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

        private bool has_music=true;

        void Start()
        {
            if (PlayerPrefs.HasKey("HasMusic"))
                has_music = PlayerPrefs.GetInt("HasMusic")==1;
            
            if(PlayerPrefs.HasKey("MasterVolume"))
                SetSliders();
            UpdateMasterVolume(masterSlider);
            UpdateMusicVolume(musicSlider);
            UpdateSFXVolume(sfxSlider);
        }
        private void Update()
        {
            music_icon.sprite = has_music ? music : music_no;
        }

        // called at the start of the game
        // set the slider values to be the saved volume settings
        void SetSliders()
        {
            masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        // called when we update the master slider
        public void UpdateMasterVolume(Slider slider)
        {
            mixer.SetFloat("MasterVolume", has_music ? convert_volume(slider.value) : -80);
            PlayerPrefs.SetFloat("MasterVolume", slider.value);
        }
        // called when we update the sfx slider
        public void UpdateSFXVolume(Slider slider)
        {
            mixer.SetFloat("SFXVolume", convert_volume(slider.value));
            PlayerPrefs.SetFloat("SFXVolume", slider.value);
        }
        // called when we update the music slider
        public void UpdateMusicVolume(Slider slider)
        {
            mixer.SetFloat("MusicVolume", convert_volume(slider.value));
            PlayerPrefs.SetFloat("MusicVolume", slider.value);
        }
        private float convert_volume(float volume)
        {
            return Mathf.Log10(volume) * 20;
        }

        public void TurnOffMusic()
        {
            has_music = !has_music;
            PlayerPrefs.SetInt("HasMusic", has_music?1:0);
            UpdateMasterVolume(musicSlider);
        }
    }
}