using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour, IChasable
{
    #region VARIABLES

    [SerializeField] private PlayerMovementController _movementController = new PlayerMovementController();
    [SerializeField] private CircleCollider2D _circleCollider;

    private List<PlayerControllerBase> _controllers;

    #endregion

    #region PROPERTIES

    public Transform ChasingTransform => transform;
    public float CircleRadius => _circleCollider.radius * transform.lossyScale.x;
    public bool IsInitialized { get; set; }

    #endregion

    #region UNITY_METHODS

    private void Update()
    {
        if (IsInitialized == false)
            return;

        _controllers.ForEach(x => x.OnUpdate());
    }

    #endregion

    #region METHODS

    public void Initialzie()
    {
        CollectControllers();
        InitializeControllers();
        IsInitialized = true;
    }

    public void CleanUp()
    {
        CleanUpControllers();
    }

    private void InitializeControllers()
    {
        _controllers.ForEach(x => x.Initialize(this));
    }

    private void CleanUpControllers()
    {
        _controllers.ForEach(x => x.CleanUp());
    }

    private void CollectControllers()
    {
        if (_controllers == null)
            _controllers = new List<PlayerControllerBase>();
        else
            _controllers.Clear();

        _controllers.Add(_movementController);

    }

    #endregion
}
