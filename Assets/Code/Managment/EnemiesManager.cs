using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Management.Enemies
{
    public class EnemiesManager : GameplayManager<EnemiesManager>
    {
        #region VARIABLES

        [SerializeField] private Enemy _enemyPrefab;

        private List<Enemy> _enemies;

        #endregion

        #region PROPERTIES

        #endregion

        #region UNITY_METHODS

        protected override void Awake()
        {
            base.Awake();
            _enemies = new();
        }

        #endregion

        #region METHODS

        public override void CleanUp()
        {
            base.CleanUp();
            CleanUpEnemeies();
        }

        private void CleanUpEnemeies()
        {
            foreach (var enemy in _enemies)
            {
                enemy.CleanUp();
                GameObject.Destroy(enemy.gameObject);
            }
        }

        public Enemy SpawnEnemy(Transform parent = null)
        {
            Enemy newEnemey = GameObject.Instantiate(_enemyPrefab, parent);

            newEnemey.transform.position = Camera.main.GetRandomVisiblePosition(newEnemey.CircleRadius);

            newEnemey.Initialize();
            _enemies.Add(newEnemey);
            return newEnemey;
        }

        public void CleanUpEnemies()
        {
            for (int i = _enemies.Count - 1; i >= 0; i--)
            {
                _enemies[i].CleanUp();
                Destroy(_enemies[i].gameObject);

                _enemies.RemoveAt(i);
            }

            _enemies.Clear();
        }

        #endregion
    }
}