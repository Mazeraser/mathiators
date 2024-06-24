using Assets.Codebase.Mechanics.Character;
using UnityEngine;

namespace Assets.Codebase.Infrastructure.Fabrics
{
    public class EnemyFactory : MonoBehaviour, IFactory<Enemy>
    {
        [SerializeField]
        private GameObject enemyPrefab;

        private GameObject _currentEnemy; //Gameobject needs to deleting from scenes
        public Enemy CurrentEnemy
        {
            get { return _currentEnemy?.GetComponent<Enemy>(); }
        }

        public Enemy Create()
        {
            Debug.Log("New enemy created");
            _currentEnemy = Instantiate(enemyPrefab);

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
                Remove();
        }
    }
}