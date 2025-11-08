using Gameplay.Management.Character;
using Gameplay.Management.Enemies;
using UnityEngine;

namespace Gameplay.Management.Core
{
    public class GameplayCoreManager : GameplayManager<GameplayCoreManager>
    {
        #region VARIABLES

        [SerializeField] private int _enemiesCount;
        [SerializeField] private Transform _gameplayField;

        #endregion

        #region PROPERTIES

        private EnemiesManager EnemiesManager => EnemiesManager.Instance;
        private CharacterManager CharacterManager => CharacterManager.Instance;

        #endregion

        #region METHODS

        public override void LateInitialize()
        {
            base.LateInitialize();

            CharacterManager.SpawnPlayer(_gameplayField);

            for (int i = 0; i < _enemiesCount; i++)
                EnemiesManager.SpawnEnemy(_gameplayField);
        }

        #endregion
    }
}