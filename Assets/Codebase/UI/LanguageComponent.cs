using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Assets.Codebase.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class LanguageComponent : MonoBehaviour
    {
        [SerializeField]
        private string[] language_text;

        private void Start()
        {
            LanguageService.LanguageChangedEvent += UpdateText;

            if (PlayerPrefs.HasKey("LanguageIndex"))
                UpdateText(PlayerPrefs.GetInt("LanguageIndex"));
            else
                UpdateText(0);
        }
        private void OnDestroy()
        {
            LanguageService.LanguageChangedEvent -= UpdateText;
        }

        private  void UpdateText(int index)
        {
            GetComponent<TMP_Text>().text = language_text[index];
        }
    }
}