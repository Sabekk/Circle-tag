using UnityEngine;

namespace Gameplay.UI
{
    public class MainMenuView : UIViewBase
    {
        #region VARIABLES

        #endregion

        #region PROPERTIES

        protected MainMenuWindow MenuWindow { get; set; }
        
        #endregion

        #region METHODS

        public override void Initialize(UIWindowBase window)
        {
            base.Initialize(window);

            if(window is MainMenuWindow menuWindow)
            {
                MenuWindow = menuWindow;
            }
        }

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