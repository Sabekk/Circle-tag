using Gameplay.Management.Core;
using Gameplay.Management.Inputs;
using Gameplay.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Management.UI
{
    public class UIManager : GameplayManager<UIManager>
    {
        #region VARIABLES

        [SerializeField] private UIWindowBase _mainMenu;

        private List<UIWindowBase> _windows;

        #endregion

        #region PROPERTIES

        private InputManager InputManager => InputManager.Instance;
        private HotkeysInputs HotkeysInputs => InputManager?.HotkeysInputs;
        private GameplayCoreManager GameplayCoreManager => GameplayCoreManager.Instance;

        #endregion

        #region METHODS

        public override void Initialize()
        {
            base.Initialize();
            _windows = new List<UIWindowBase>();

            OpenWindow(_mainMenu);
        }

        protected override void AttachEvents()
        {
            base.AttachEvents();

            if (HotkeysInputs != null)
            {
                HotkeysInputs.OnPauseBackCall += HandlePauseBackCall;
            }
        }

        protected override void DetachEvents()
        {
            base.DetachEvents();

            if (HotkeysInputs != null)
            {
                HotkeysInputs.OnPauseBackCall -= HandlePauseBackCall;
            }
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

            if (_windows.Count == 0)
                GameplayCoreManager.ChangeGameState(GameStateType.GAMEPLAY);
        }


        #region HANDLERS

        private void HandlePauseBackCall()
        {
            if (_windows.Count != 0)
                return;

            GameplayCoreManager.Instance.ChangeGameState(GameStateType.PAUSE);
            OpenWindow(_mainMenu);
        }

        #endregion

        #endregion
    }
}