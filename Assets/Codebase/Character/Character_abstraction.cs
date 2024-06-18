using System;
using UnityEngine;

namespace Assets.Codebase.Character
{
    public abstract class Character_abstraction : MonoBehaviour, ICharacter, ILive
    {
        public static event Action<ILive, string> BornedEvent;

        private const int MAX_HP = 20; //HP - health point
        private const int MAX_DP = 30; //DP - damage point
        private const int MAX_PS = 10; //PS - permanent shield

        [SerializeField]
        [Range(1,MAX_HP)]
        private int _hp;

        [SerializeField]
        [Range(1,MAX_DP)]
        private int _dp;
        
        [SerializeField]
        [Range(0,MAX_PS)]
        private int _ps;

        protected ILive _target;

        public int HP
        {
            get { return _hp; }
            set { _hp = value; }
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

        public bool IsDead() { return GetComponent<ILive>().HP <= 0; }

        public void TakeDamage(int damage)
        {
            HP -= Mathf.Clamp(damage - PermanentShield, 1, MAX_HP);
            Debug.Log(gameObject.tag + " " + HP);
        }

        public void Attack(ILive target)
        {
            Debug.Log(tag+ " is attacking");
            target.TakeDamage(DP);
        }

        public virtual void Start()
        {
            
        }
    }
}