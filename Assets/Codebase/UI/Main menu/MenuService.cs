using UnityEngine;
using TMPro;
using Zenject;
using System.Runtime.InteropServices;

namespace Assets.Codebase.UI.MainMenu
{
    public class MenuService : MonoBehaviour
    {

        [DllImport(("_Internal"))]
        private static extern void LoadData();

        private Fade _fade;

        [SerializeField]
        private float _durationTime;

        [SerializeField]
        private TMP_Text score_field;

        [Inject]
        private void Construct(Fade fade)
        {
            _fade = fade;
        }

        private void Start()
        {
            LanguageService.LanguageChangedEvent += UpdateScoreText;

            LoadData();
        }

        public void ActivateBlock(CanvasGroup canvasGroup)
        {
            canvasGroup.blocksRaycasts = true;
            _fade.FadeIn(_durationTime, canvasGroup);
        }
        public void DeactivateBlock(CanvasGroup canvasGroup)
        {
            canvasGroup.blocksRaycasts = false;
            _fade.FadeOut(_durationTime, canvasGroup);
        }

        private void UpdateScoreText(int language_index) => score_field.text = score_field.text + ": " + (PlayerPrefs.HasKey("HighScore") ? PlayerPrefs.GetInt("HighScore").ToString() : "0");

        private void SetScore(int score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        public void ToGame() => _fade.ChangeScene(2);
        public void QuitGame() => Application.Quit();
    }
}