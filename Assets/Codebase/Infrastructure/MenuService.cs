using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Assets.Codebase.Infrastructure
{
    public class MenuService : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text score_field;

        private void Start()
        {
            score_field.text = "Best score: " + (PlayerPrefs.HasKey("HighScore") ? PlayerPrefs.GetInt("HighScore").ToString() : "0");
        }

        public void QuitGame() => Application.Quit();
    }
}