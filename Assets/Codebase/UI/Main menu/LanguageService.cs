using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageService : MonoBehaviour
{
    public static event Action<int> LanguageChangedEvent;

    private int _language_index;
    public int LanguageIndex
    {
        set 
        { 
            Debug.Log(value); 
            _language_index = value; 
            SetFlag(_language_index); 
            PlayerPrefs.SetInt("LanguageIndex", _language_index);
        }
    }

    [SerializeField]
    private Sprite[] _flags;
    [SerializeField]
    private Image _flag;


    private void Start()
    {
        if (PlayerPrefs.HasKey("LanguageIndex"))
            LanguageIndex = PlayerPrefs.GetInt("LanguageIndex");
        else
            LanguageIndex = 0;
        LanguageChangedEvent?.Invoke(_language_index);
    }
    public void ChangeIndex(int turn)
    {
        LanguageIndex = _language_index + turn >= _flags.Length ? 0 : _language_index + turn;
        LanguageChangedEvent?.Invoke(_language_index);
    }

    private void SetFlag(int index)
    {
        _flag.sprite = _flags[index];
    }
}
