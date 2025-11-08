using Gameplay.Management.Inputs;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputs : InputsBase, InputBinds.IMovementActions
{
    #region ACTIONS

    public event Action<Vector2> OnMoveInDirection;

    #endregion

    #region CONSTRUCTORS

    public CharacterInputs(InputBinds binds) : base(binds)
    {
        Binds.Movement.SetCallbacks(this);
    }

    #endregion

    #region METHODS

    public override void Enable()
    {
        Binds.Movement.Enable();
    }

    public override void Disable()
    {
        Binds.Movement.Disable();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (!context.started)
            OnMoveInDirection?.Invoke(context.ReadValue<Vector2>());
    }

    #endregion
}
