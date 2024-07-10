using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Codebase.UI
{

    [RequireComponent(typeof(AudioSource))]
    public class MusicSingletone : MonoBehaviour
    {
        public static MusicSingletone Instance;

        private AudioSource _musicSource;

        [SerializeField]
        private AudioClip[] _musicClips;

        private void Start()
        {
            if (Instance != null)
                Destroy(this.gameObject);
            else
                Instance = this;

            DontDestroyOnLoad(gameObject);

            _musicSource = GetComponent<AudioSource>();
        }
        private void Update()
        {
            if (!_musicSource.isPlaying)
                SetMusic();
        }

        private void SetMusic()
        {
            _musicSource.Stop();
            _musicSource.clip = _musicClips[Random.Range(0, _musicClips.Length)];
            Debug.Log("Playing");
            _musicSource.Play();
        }
    }
}