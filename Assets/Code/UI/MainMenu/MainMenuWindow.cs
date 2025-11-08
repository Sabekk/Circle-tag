using Gameplay.Management.Core;
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
            GameplayCoreManager.Instance.StartGame();
            Close();
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        #endregion
    }
}
