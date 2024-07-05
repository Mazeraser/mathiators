using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Assets.Codebase.UI.MainMenu
{
    public class CharacterCreator : MonoBehaviour
    {
        [SerializeField]
        private GameObject _playerPrefab;

        private int[] _characteristics;

        [SerializeField]
        private TMP_Text[] _characteristic_field;

        [SerializeField]
        private TMP_Text _balance_field;

        [SerializeField]
        private Image _skin_window;

        [SerializeField]
        private Sprite[] _skins;

        [SerializeField]
        private RuntimeAnimatorController[] _animators;

        private int _selected_index;
        private int SelectedIndex
        {
            set
            {
                _selected_index = Mathf.Clamp(value,0,_skins.Length-1);
                _skin_window.sprite = _skins[_selected_index];
            }
        }

        private void Start()
        {
            LanguageService.LanguageChangedEvent += UpdateBalanceText;

            SelectedIndex = 0;

            _characteristics = new int[3];
            LoadCharacteristics();
        }
        private void OnDestroy()
        {
            LanguageService.LanguageChangedEvent -= UpdateBalanceText;
        }
        private void Update()
        {
            for (int i=0; i < _characteristics.Length; i++)
            {
                _characteristic_field[i].text = _characteristics[i].ToString();
            }
        }

        private void UpdateBalanceText(int language_index) => _balance_field.text = _balance_field.text + ": " + (_characteristics[0] + _characteristics[1] + _characteristics[2]).ToString();

        public void plus_characteristic(int index)
        {
            _characteristics[index] += 1;
        }
        public void minus_characteristic(int index)
        {
            _characteristics[index] -= 1;
        }
        public void change_skin(int turn)
        {
            SelectedIndex = _selected_index+turn;
        }

        private void LoadCharacteristics()
        {
            if (PlayerPrefs.HasKey("PlayerHP"))
            {
                _characteristics[0] = PlayerPrefs.GetInt("PlayerHP");
                _characteristics[1] = PlayerPrefs.GetInt("PlayerDP");
                _characteristics[2] = PlayerPrefs.GetInt("PlayerPS");
            }
            else
            {
                _characteristics[0] = 1;
                _characteristics[1] = 1;
                _characteristics[2] = 0;
            }
        }
        private void SaveCharacteristics()
        {
             PlayerPrefs.SetInt("PlayerHP", _characteristics[0]);
             PlayerPrefs.SetInt("PlayerDP", _characteristics[1]);
             PlayerPrefs.SetInt("PlayerPS", _characteristics[2]);

             _playerPrefab.GetComponent<Animator>().runtimeAnimatorController = _animators[_selected_index];
        }

        public void ToGame()
        {
            SaveCharacteristics();
        }
    }
}