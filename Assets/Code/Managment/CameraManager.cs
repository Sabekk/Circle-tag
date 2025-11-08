using Gameplay.Management.Core;
using System;
using UnityEngine;

namespace Gameplay.Management.UI
{
    public class CameraManager : GameplayManager<UIManager>
    {
        #region VARIABLES

        [SerializeField] private Color _defaultColor;
        [SerializeField] private Color _playColor;

        #endregion

        #region PROPERTIES

        public Camera Camera => Camera.main;
        private GameplayCoreManager GameplayCoreManager => GameplayCoreManager.Instance;

        #endregion

        #region METHODS

        public override void LateInitialize()
        {
            base.LateInitialize();
            RefreshCameraColor();
        }

        protected override void AttachEvents()
        {
            base.AttachEvents();
            if (GameplayCoreManager)
            {
                GameplayCoreManager.OnGameStateChanged += HandleGameStateChanged;
            }
        }

        protected override void DetachEvents()
        {
            base.DetachEvents();
            if (GameplayCoreManager)
            {
                GameplayCoreManager.OnGameStateChanged -= HandleGameStateChanged;
            }
        }

        private void RefreshCameraColor()
        {
            if (GameplayCoreManager.GameState == GameStateType.GAMEPLAY)
                Camera.backgroundColor = _playColor;
            else
                Camera.backgroundColor = _defaultColor;
        }

        #region HANDLERS

        private void HandleGameStateChanged(GameStateType gameState)
        {
            RefreshCameraColor();
        }

        #endregion

        #endregion
    }
}