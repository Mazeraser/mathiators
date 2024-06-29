using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Assets.Codebase.UI.MainMenu
{
    [RequireComponent(typeof(Button))]
    public class CharacteristicButton : MonoBehaviour
    {
        [SerializeField]
        private int _hide_value;

        [SerializeField]
        private TMP_Text _characteristic_field;

        private void Update()
        {
            GetComponent<Button>().interactable = Convert.ToInt32(_characteristic_field.text) != _hide_value;
        }
    }
}