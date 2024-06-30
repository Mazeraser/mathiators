using Assets.Codebase.Mechanics.Difficulty;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Codebase.UI.MainMenu
{
    public class DifficultySelecter : MonoBehaviour
    {
        public static event Action DifficultySelectedEvent;

        [SerializeField]
        private bool _selected;

        [SerializeField]
        private DifficultyAbsctraction difficulty;

        [SerializeField]
        private TMP_Text _description;

        private void SetDifficulty()
        {
            PlayerPrefs.SetInt("Minimal expression length", difficulty.MinimalExpressionLength);
            PlayerPrefs.SetInt("Maximum expression length", difficulty.MaximalExpressionLength);
            PlayerPrefs.SetInt("Minimal number", difficulty.MinimalNumber);
            PlayerPrefs.SetInt("Maximum number", difficulty.MaximumNumber);
            PlayerPrefs.SetFloat("DecideTime", difficulty.DecideTime);
        }
        private void SetDescription()
        {
            _description.text = "";
            _description.text += "Minimal expression length: " + difficulty.MinimalExpressionLength+"\n";
            _description.text += "Maximal expression length: " + difficulty.MaximalExpressionLength+"\n";
            _description.text += "Minimal number(obtained in expression): " + difficulty.MinimalNumber+"\n";
            _description.text += "Maximal number(obtained in expression): " + difficulty.MaximumNumber+"\n";
            _description.text += "Time for decision: " + difficulty.DecideTime+" seconds\n";
        }

        private void Start()
        {
            DifficultySelecter.DifficultySelectedEvent += RemoveFlag;
        }
        private void OnDestroy()
        {
            DifficultySelecter.DifficultySelectedEvent += RemoveFlag;
        }

        private void Update()
        {
            GetComponent<Button>().interactable = !_selected;
            if (_selected)
            {
                SetDifficulty();
                SetDescription();
            }
        }

        private void RemoveFlag()
        {
            _selected = false;
        }

        public void Select()
        {
            DifficultySelectedEvent?.Invoke();
            _selected = true;
        }
    }
}