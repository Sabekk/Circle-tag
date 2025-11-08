using Gameplay.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Management
{
    public class UIManager : GameplayManager<UIManager>
    {
        #region VARIABLES

        [SerializeField] private UIWindowBase _mainMenu;

        private List<UIWindowBase> _windows;

        #endregion

        #region PROPERTIES

        #endregion

        #region METHODS

        public override void Initialzie()
        {
            base.Initialzie();
            _windows = new List<UIWindowBase>();

            OpenWindow(_mainMenu);
        }

        public void OpenWindow(UIWindowBase window)
        {
            _windows.Remove(window);
            _windows.Add(window);

            window.Initialize();

            window.gameObject.SetActive(true);
        }

        public void CloseWindow(UIWindowBase window)
        {
            _windows.Remove(window);

            window.CleanUp();
            window.gameObject.SetActive(false);
        }

        #endregion
    }
}