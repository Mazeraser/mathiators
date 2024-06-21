using Assets.Codebase.Mechanics.Character;
using UnityEngine;

namespace Assets.Codebase.Infrastructure.Fabrics
{
    public class EnemyFactory : MonoBehaviour, IFactory<Enemy>
    {
        [SerializeField]
        private GameObject enemyPrefab;

        private GameObject _currentEnemy; //Gameobject needs to deleting from scenes
        public ILive CurrentEnemy
        {
            get { return _currentEnemy?.GetComponent<ILive>(); }
        }

        public Enemy Create()
        {
            _currentEnemy = Instantiate(enemyPrefab);

            return _currentEnemy.GetComponent<Enemy>();
        }

        public void Remove()
        {
            Destroy( _currentEnemy );
            _currentEnemy=null;

            Create();
        }

        private void Update()
        {
            if (_currentEnemy == null)
                Create();
            if (CurrentEnemy.IsDead())
                Remove();
        }
    }
}