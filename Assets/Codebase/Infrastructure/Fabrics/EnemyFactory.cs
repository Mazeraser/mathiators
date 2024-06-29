using Assets.Codebase.Mechanics.Character;
using System;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Codebase.Infrastructure.Fabrics
{
    public class EnemyFactory : MonoBehaviour, IFactory<Enemy>
    {
        public static event Action EnemyDeath;

        [SerializeField]
        private GameObject enemyPrefab;

        [SerializeField]
        private AnimatorController[] skins;

        private GameObject _currentEnemy; //Gameobject needs to deleting from scenes
        public Enemy CurrentEnemy
        {
            get { return _currentEnemy?.GetComponent<Enemy>(); }
        }

        public Enemy Create()
        {

            _currentEnemy = Instantiate(enemyPrefab);
            _currentEnemy.GetComponent<Animator>().runtimeAnimatorController = skins[UnityEngine.Random.Range(0,skins.Length)];

            return _currentEnemy.GetComponent<Enemy>();
        }

        public void Remove()
        {
            Destroy(_currentEnemy);
            _currentEnemy=null;
            Create();
        }

        private void Start()
        {
            Create();
        }
        private void Update()
        {
            if (CurrentEnemy.IsDead())
            {
                EnemyDeath?.Invoke();
                Remove();
            }
        }
    }
}