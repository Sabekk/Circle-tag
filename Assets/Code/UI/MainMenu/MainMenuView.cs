using Gameplay.Management.Core;
using UnityEngine;

namespace Gameplay.UI
{
    public class MainMenuView : UIViewBase
    {
        #region VARIABLES

        #endregion

        #region PROPERTIES

        protected MainMenuWindow MenuWindow { get; set; }
        private GameplayCoreManager GameplayCoreManager => GameplayCoreManager.Instance;

        #endregion

        #region METHODS

        public override void InitializeWindow(UIWindowBase window)
        {
            base.InitializeWindow(window);

            if(window is MainMenuWindow menuWindow)
                MenuWindow = menuWindow;
        }

        public override void Initialize()
        {
            base.Initialize();
            CheckButtonsByGameState();
        }

        protected override void AttachEvents()
        {
            base.AttachEvents();
            GameplayCoreManager.OnGameStateChanged += HandleGameStateChenged;
        }

        protected override void DetachEvents()
        {
            base.DetachEvents();
            GameplayCoreManager.OnGameStateChanged -= HandleGameStateChenged;
        }

        private void CheckButtonsByGameState()
        {
            _closeButton?.gameObject.SetActive(GameplayCoreManager.GameState != GameStateType.MAIN_MENU);
        }

        #region HANDLERS

        private void HandleGameStateChenged(GameStateType gameState)
        {
            CheckButtonsByGameState();
        }

        #endregion

        #region UI_ACTIONS

        public void PlayGame()
        {
            MenuWindow.PlayGame();
        }

        public void OpenSettings()
        {
            MenuWindow.OpenSettingsView();
        }

        public void ExitGame()
        {
            MenuWindow.ExitGame();
        }

        #endregion

        #endregion
    }
}