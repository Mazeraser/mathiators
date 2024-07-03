using UnityEngine;
using TMPro;
using Zenject;

namespace Assets.Codebase.UI.MainMenu
{
    public class MenuService : MonoBehaviour
    {
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
            score_field.text = "Best score: " + (PlayerPrefs.HasKey("HighScore") ? PlayerPrefs.GetInt("HighScore").ToString() : "0");
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

        public void ToGame() => _fade.ChangeScene(2);
        public void QuitGame() => Application.Quit();
    }
}