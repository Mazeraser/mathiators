using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Codebase.Mechanics.Timer
{
    public class Timer : MonoBehaviour, ITimer
    {
        [SerializeField]
        [Range(4f,60f)]
        private float _decideTime;

        private float _timer;
        public float TimeRemaining
        {
            get { return _timer; }
        }

        public bool TimeHasGone
        {
            get { return _timer <= 0; }
        }

        private void Start()
        {
            _decideTime = _decideTime > 0 ? _decideTime : Random.Range(6f, 10f);
            _timer = _decideTime;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (TimeHasGone)
                UpdateTimer();
        }

        public void UpdateTimer()
        {
            _timer = _decideTime;
        }
    }
}