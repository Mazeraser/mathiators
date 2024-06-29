using Assets.Codebase.Infrastructure;
using System;
using UnityEngine;

namespace Assets.Codebase.Mechanics.Character
{
    public abstract class Character_abstraction : MonoBehaviour, ICharacter, ILive, IActive
    {
        public static event Action<Character_abstraction, string> CharacteristicsUpdatedEvent;

        private const int MAX_HP = 20; //HP - health point
        private const int MAX_DP = 30; //DP - damage point
        private const int MAX_PS = 10; //PS - permanent shield

        private int _hp;
        private int _current_hp;

        private int _dp;
        
        private int _ps;
    
        private enum CharacterState
        {
            idle = 0,
            attack=1,
            take_damage=2,
            death=3,
        }
        private CharacterState _state;
        public int StateIndex
        {
            get { return (int)_state; }
            set { _state = (CharacterState)value; }
        }

        public int MaxHP
        {
            get { return _hp; }
        }
        public int CurrentHP
        {
            get { return _current_hp; }
            set { _current_hp = value; }
        }
        public int PermanentShield
        {
            get { return _ps; }
        }
        public int DP
        {
            get { return _dp; }
            set { _dp = value; }
        }

        public void SetCharacteristics(int[] characteristics)
        {
            _hp = characteristics[0];
            _current_hp = _hp;
            _dp = characteristics[1];
            _ps = characteristics[2];

            CharacteristicsUpdatedEvent?.Invoke(this, gameObject.tag);
        }

        public void LoadCharacteristics()
        {
            _hp = PlayerPrefs.GetInt("PlayerHP");
            _current_hp = _hp;
            _dp = PlayerPrefs.GetInt("PlayerDP");
            _ps = PlayerPrefs.GetInt("PlayerPS");

            CharacteristicsUpdatedEvent?.Invoke(this, gameObject.tag);
        }

        public bool IsDead() 
        { 
            if(GetComponent<ILive>().CurrentHP <= 0)
            {

                _state = CharacterState.death;
                return true;
            }
            return false;
        }

        public void TakeDamage(int damage)
        {
            _state = CharacterState.take_damage;
            CurrentHP -= Mathf.Clamp(damage - PermanentShield, 1, MaxHP);
            Debug.Log(name + "has been attacked");
        }

        public void Attack()
        {
            _state = CharacterState.attack;
            FoundTarget().TakeDamage(DP);
            Debug.Log(name + "is attacking");
        }

        public virtual ILive FoundTarget()
        {
            Debug.Log("Target is changed");
            return null;
        }

        public void GenerateChars(int balance_points)
        {
            int counter = 2;

            _hp = 1;
            _dp = 1;
            _ps = 0;

            while (counter < balance_points)
            {
                int index = UnityEngine.Random.Range(0, 3);
                int val=0;

                switch (index)
                {
                    case 0:
                        val = UnityEngine.Random.Range(0, Mathf.Min(GameplayService.Balance_Points - counter, MAX_HP) + 1);
                        _hp += val;
                        break;
                    case 1:
                        val = UnityEngine.Random.Range(0, Mathf.Min(GameplayService.Balance_Points - counter, MAX_DP) + 1);
                        _dp += val;
                        break;
                    case 2:
                        val = UnityEngine.Random.Range(0, Mathf.Min(GameplayService.Balance_Points - counter, MAX_PS) + 1);
                        _ps += val;
                        break;
                }

                counter += val;
            }
            CharacteristicsUpdatedEvent?.Invoke(this, gameObject.tag);
        }

        public virtual void Start()
        {
            GenerateChars(GameplayService.Balance_Points);
            _current_hp = _hp;
        }
    }
}