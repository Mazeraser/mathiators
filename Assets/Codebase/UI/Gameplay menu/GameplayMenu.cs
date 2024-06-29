using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Codebase.UI.GameplayMenu
{
    [RequireComponent(typeof(Image))]
    public class GameplayMenu : MonoBehaviour
    {
        public static event Action<bool> MenuModeChangedEvent;

        private bool _isActive;

        public void change_menu_mode(bool value)
        {
            _isActive = value;
            GetComponent<Image>().enabled = value;
            for(int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).gameObject.SetActive(_isActive);
            MenuModeChangedEvent?.Invoke(!_isActive);
        }

        private void Start()
        {
            change_menu_mode(false);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                change_menu_mode(!_isActive);
            }
        }

        public void Quit(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}