using Assets.Codebase.Infrastructure.Fabrics;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Assets.Codebase.Mechanics.EnemyScore
{
    public class EnemyScore : MonoBehaviour
    {
        [DllImport(("_Internal"))]
        private static extern void SaveData(int score);

        private int _score;
        public int Score
        {
            get { return _score; }
        }

        private int _highScore;

        private void Awake()
        {
            EnemyFactory.EnemyDeath += RaiseScore;
        }
        private void OnDestroy()
        {
            EnemyFactory.EnemyDeath -= RaiseScore;
        }

        private void Start()
        {
            _score = 0;
            if (PlayerPrefs.HasKey("HighScore"))
                _highScore = PlayerPrefs.GetInt("HighScore");
            else
                _highScore = 0;
        }
        private void Update()
        {
            if (_score > _highScore)
                _highScore = _score;
            UpdatePlayerPrefs();
        }

        private void UpdatePlayerPrefs()
        {
            PlayerPrefs.SetInt("HighScore", _highScore);
            SaveData(_highScore);
        }
        private void RaiseScore()
        {
            _score++;
        }
    }
}