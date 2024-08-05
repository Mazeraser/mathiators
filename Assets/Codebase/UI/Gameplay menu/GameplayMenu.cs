using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Assets.Codebase.UI.GameplayMenu
{
    [RequireComponent(typeof(Image))]
    public class GameplayMenu : MonoBehaviour
    {
        private Fade _fade;

        [SerializeField]
        private float _fadeDuration;

        public static event Action<bool> MenuModeChangedEvent;

        private bool _isActive;

        [Inject]
        private void Construct(Fade fade)
        {
            _fade = fade;
        }

        public void change_menu_mode(bool value, float time)
        {
            _isActive = value;
            GetComponent<CanvasGroup>().blocksRaycasts = value;
            Cursor.visible = value;

            if (_isActive)
                _fade.FadeIn(time, GetComponent<CanvasGroup>());
            else
                _fade.FadeOut(time, GetComponent<CanvasGroup>());

            MenuModeChangedEvent?.Invoke(!_isActive);
        }
        public void change_menu_mode(bool value)
        {
            _isActive = value;
            GetComponent<CanvasGroup>().blocksRaycasts = value;
            Cursor.visible = value;

            if (_isActive)
                _fade.FadeIn(_fadeDuration, GetComponent<CanvasGroup>());
            else
                _fade.FadeOut(_fadeDuration, GetComponent<CanvasGroup>());

            MenuModeChangedEvent?.Invoke(!_isActive);
        }

        private void Start()
        {
            //change_menu_mode(false, 0f);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                change_menu_mode(!_isActive);
            }
        }

        public void Quit()
        {
            _fade.ChangeScene(1);
        }
    }
}