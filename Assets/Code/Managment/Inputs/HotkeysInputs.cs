using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Management.Inputs
{
    public class HotkeysInputs : InputsBase, InputBinds.IHotkeysActions
    {
        #region ACTIONS

        public event Action OnPauseBackCall;

        #endregion

        #region CONSTRUCTORS

        public HotkeysInputs(InputBinds binds) : base(binds)
        {
            Binds.Hotkeys.SetCallbacks(this);
        }

        #endregion

        #region METHODS

        public override void Enable()
        {
            Binds.Hotkeys.Enable();
        }

        public override void Disable()
        {
            Binds.Hotkeys.Disable();
        }

        public void OnPauseBack(InputAction.CallbackContext context)
        {
            if (context.started)
                OnPauseBackCall?.Invoke();
        }

        #endregion
    }
}