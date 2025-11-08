using Gameplay.Management.Inputs;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI
{
    public class UIViewBase : MonoBehaviour
    {
        #region VARIABLES

        [SerializeField] protected Button _closeButton;

        #endregion

        #region PROPERTIES

        protected UIWindowBase Window { get; set; }
        private InputManager InputManager => InputManager.Instance;
        private HotkeysInputs HotkeysInputs => InputManager?.HotkeysInputs;

        #endregion

        #region METHODS

        public virtual void InitializeWindow(UIWindowBase window)
        {
            Window = window;
        }

        public virtual void Initialize()
        {
            DetachEvents();
            AttachEvents();
        }

        public virtual void CleanUp()
        {
            DetachEvents();
        }

        protected virtual void AttachEvents()
        {
            if (HotkeysInputs != null)
            {
                HotkeysInputs.OnPauseBackCall += HandlePauseBackCall;
            }
        }

        protected virtual void DetachEvents()
        {
            if (HotkeysInputs != null)
            {
                HotkeysInputs.OnPauseBackCall -= HandlePauseBackCall;
            }
        }

        #region HANDLERS

        private void HandlePauseBackCall()
        {
            if (_closeButton.gameObject.activeInHierarchy == false)
                return;

            if (_closeButton.interactable == false)
                return;

            if (_closeButton.enabled == false)
                return;

            Back();
        }

        #endregion

        #region UI_ACTIONS

        public void Back()
        {
            Window.ToggleView(this, false);
        }

        #endregion

        #endregion
    }
}