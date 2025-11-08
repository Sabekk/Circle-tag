using UnityEngine;

public abstract class PlayerControllerBase
{
    #region VARIABLES

    #endregion

    #region PROPERTIES

    protected PlayerCharacter Character { get; set; }

    #endregion

    #region METHODS

    public virtual void Initialize(PlayerCharacter character)
    {
        Character = character;
        AttachEvents();
    }

    public virtual void CleanUp()
    {
        DetachEvents();
    }

    public virtual void OnUpdate()
    {

    }

    protected virtual void AttachEvents()
    {

    }
    protected virtual void DetachEvents()
    {

    }

    #endregion
}

