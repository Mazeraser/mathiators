using Assets.Codebase.Mechanics.Character;
using UnityEngine;

namespace Assets.Codebase.Mechanics
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimatorComponent : MonoBehaviour
    {
        private Animator _animator;
        private Character_abstraction _character;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _character = GetComponent<Character_abstraction>();
        }
        private void Update()
        {
            switch (_character.StateIndex)
            {
                case 1:
                    _animator.SetTrigger("Attack");
                    break;
                case 2:
                    _animator.SetTrigger("TakeDamage");
                    break;
                case 3:
                    _animator.SetTrigger("Death");
                    break;
            }
            _character.StateIndex = 0;
        }
    }
}