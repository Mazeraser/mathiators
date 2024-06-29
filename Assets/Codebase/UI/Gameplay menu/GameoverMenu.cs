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
        private Player _player;

        [Inject]
        private void Construct(Player player)
        {
            _player = player;
        }

        private void ActivateMenu()
        {
            GetComponent<Image>().enabled = true;
            for (int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).gameObject.SetActive(true);
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void ToMenu(int index)
        {
            SceneManager.LoadScene(index);
        }

        private void Update()
        {
            if (_player.IsDead())
                ActivateMenu();
        }
    }
}