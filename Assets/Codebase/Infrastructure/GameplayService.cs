using Assets.Codebase.Mechanics.Character;
using Assets.Codebase.Mechanics.Timer;
using UnityEngine;
using Zenject;
using System;
using TMPro;

namespace Assets.Codebase.Infrastructure
{
    public class GameplayService : MonoBehaviour
    {
        public static event Action EndGameEvent;
        public static event Action<string> UpdateExpressionEvent;

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

        private void Update()
        {
            if (_player.GetComponent<ILive>().IsDead())
            {
                EndGameEvent?.Invoke();
            }

            if (_timer.TimeHasGone)
            {
                SendAnswer();
                _timer.UpdateTimer();
            }
        }//TODO: Doing a few tasks, maybe need to refactor

        public void SendAnswer()
        {
            UpdateExpressionEvent?.Invoke(_inputField.text);
        }
    }
}