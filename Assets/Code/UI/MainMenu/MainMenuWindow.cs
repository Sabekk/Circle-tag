using System;
using UnityEngine;

namespace Gameplay.UI
{
    public class MainMenuWindow : UIWindowBase
    {
        #region VARIABLES

        [SerializeField] private UIViewBase _settingsView;

        #endregion

        #region PROPERTIES

        #endregion

        #region METHODS

        public void OpenSettingsView()
        {
            ToggleView(_settingsView, true);
        }

        public void PlayGame()
        {

        }

        public void ExitGame()
        {

        }

        #endregion
    }
}
