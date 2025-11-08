using Gameplay.Management.Character;
using Gameplay.Management.Enemies;
using System;
using UnityEngine;

namespace Gameplay.Management.Core
{
    public class GameplayCoreManager : GameplayManager<GameplayCoreManager>
    {
        #region ACTIONS

        public event Action<GameStateType> OnGameStateChanged;

        #endregion

        #region VARIABLES

        [SerializeField] private int _enemiesCount;
        [SerializeField] private Transform _gameplayField;

        private GameStateType _currentGamestate;

        #endregion

        #region PROPERTIES

        public GameStateType GameState
        {
            get => _currentGamestate;
            private set
            {
                if (value == _currentGamestate)
                    return;
                _currentGamestate = value;
                OnGameStateChanged?.Invoke(_currentGamestate);
            }
        }

        private EnemiesManager EnemiesManager => EnemiesManager.Instance;
        private CharacterManager CharacterManager => CharacterManager.Instance;

        #endregion

        #region UNITY_METHODS

        protected override void Awake()
        {
            base.Awake();
            GameState = GameStateType.MAIN_MENU;
        }

        #endregion

        #region METHODS

        public void StartGame()
        {
            ResetGame();
            InitGame();
            GameState = GameStateType.GAMEPLAY;
        }

        public void ChangeGameState(GameStateType newState)
        {
            GameState = newState;
        }

        private void InitGame()
        {
            CharacterManager.SpawnPlayer(_gameplayField);

            for (int i = 0; i < _enemiesCount; i++)
                EnemiesManager.SpawnEnemy(_gameplayField);
        }

        private void ResetGame()
        {
            EnemiesManager.CleanUpEnemies();
            CharacterManager.CleanUpPlayer();
        }

        #endregion
    }
}