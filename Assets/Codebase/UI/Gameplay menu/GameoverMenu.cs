using Assets.Codebase.Mechanics.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Assets.Codebase.UI.GameplayMenu
{
    public class GameoverMenu : MonoBehaviour
    {
        private Fade _fade;

        private Player _player;

        [Inject]
        private void Construct(Player player, Fade fade)
        {
            _player = player;
            _fade = fade;
        }

        private void ActivateMenu()
        {
            _fade.FadeIn(0.1f, GetComponent<CanvasGroup>());
        }

        public void Restart()
        {
            _fade.ChangeScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void ToMenu()
        {
            _fade.ChangeScene(1);
        }

        private void Update()
        {
            if (_player.IsDead())
                ActivateMenu();
        }
    }
}