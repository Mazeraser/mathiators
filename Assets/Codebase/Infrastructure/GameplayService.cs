using System.Runtime.InteropServices;
using Assets.Codebase.Mechanics.Character;
using Assets.Codebase.Mechanics.Timer;
using UnityEngine;
using Zenject;
using System;
using TMPro;
using Assets.Codebase.UI;

namespace Assets.Codebase.Infrastructure
{
    public class GameplayService : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void ShowStartAdv();

        public static event Action EndGameEvent;
        public static event Action<string> UpdateExpressionEvent;

        public static int Balance_Points = 0;

        private Player _player;
        private ITimer _timer;

        [SerializeField]
        private TMP_InputField _inputField;


        [Inject]
        private void Construct(Player player, ITimer timer)
        {
            _player = player;
            _timer = timer;
        }

        private void Start()
        {
            ShowStartAdv(); //yandexs
            MusicSingletone.Instance.StopMusic();
        }
        private void Update()
        {
            if (_player.GetComponent<ILive>().IsDead())
            {
                EndGameEvent?.Invoke();
            }

            if (_timer.TimeHasGone)
            {
                SendAnswer("0");
                _timer.UpdateTimer();
            }

            if (Input.GetKeyDown(KeyCode.Return))
                SendAnswer();
        }

        public void SendAnswer(string answer)
        {
            _timer.UpdateTimer();
            UpdateExpressionEvent?.Invoke(answer);
        }
        public void SendAnswer()
        {
            _timer.UpdateTimer();
            UpdateExpressionEvent?.Invoke(_inputField.text);
        }
    }
}