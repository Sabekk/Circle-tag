using Gameplay.Management.Inputs;
using System;
using UnityEngine;

public class PlayerMovementController : PlayerControllerBase
{
    #region VARIABLES

    [SerializeField] private float _movementSpeed = 3;

    private Vector2 _destination;

    #endregion

    #region PROPERTIES

    private InputManager InputManager => InputManager.Instance;
    private CharacterInputs CharacterInputs => InputManager?.CharacterInputs;


    #endregion

    #region METHODS

    public override void OnUpdate()
    {
        base.OnUpdate();
        TryMoveCharacter();
    }

    protected override void AttachEvents()
    {
        base.AttachEvents();
        CharacterInputs.OnMoveInDirection += HandleMoveInDirection;
    }

    protected override void DetachEvents()
    {
        base.DetachEvents();
        CharacterInputs.OnMoveInDirection -= HandleMoveInDirection;
    }

    private void TryMoveCharacter()
    {
        if (_destination == Vector2.zero)
            return;

        var pos = Character.transform.position + (Vector3)(_destination * _movementSpeed * Time.deltaTime);
        Character.transform.position = pos.GetPositionClampedToCamera(Camera.main, Character.CircleRadius);
    }

    #region HANDLERS

    private void HandleMoveInDirection(Vector2 moveDirection)
    {
        _destination = moveDirection;
    }

    #endregion

    #endregion
}
