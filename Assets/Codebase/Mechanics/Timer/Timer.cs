using UnityEngine;
using Assets.Codebase.UI.GameplayMenu;

namespace Assets.Codebase.Mechanics.Timer
{
    public class Timer : MonoBehaviour, ITimer
    {
        [SerializeField]
        [Range(4,60)]
        private float _decideTime;

        private bool _isTurning=false;

        private float _timer;
        public float TimeRemaining
        {
            get { return Mathf.Round(_timer*10)/10;}
        }

        public float ProcentFilling
        {
            get { return Mathf.Lerp(0f, _decideTime, TimeRemaining); }
        }

        public bool TimeHasGone
        {
            get { return _timer <= 0; }
        }

        private void Awake()
        {
            GameplayMenu.MenuModeChangedEvent += ChangeTimerMode;
        }
        private void OnDestroy()
        {
            GameplayMenu.MenuModeChangedEvent -= ChangeTimerMode;
        }
        private void Start()
        {
            if (PlayerPrefs.HasKey("DecideTime"))
                _decideTime = PlayerPrefs.GetFloat("DecideTime");
            _timer = _decideTime;
            //StartTimer();
        }

        private void Update()
        {
            if(_isTurning)
                _timer -= Time.deltaTime;
        }

        public void StartTimer()
        {
            _isTurning = true;
        }
        public void UpdateTimer()
        {
            _timer = _decideTime;
        }

        private void ChangeTimerMode(bool value)
        {
            _isTurning = value;
        }
    }
}