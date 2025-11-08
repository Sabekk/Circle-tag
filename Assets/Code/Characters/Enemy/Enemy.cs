using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] private EnemyWalkBehaviour _walkBehaviour;

    private float _currentTime;

    #endregion

    #region PROPERTIES

    public bool IsInitialized { get; set; }
    public float CircleRadius => _circleCollider.radius * transform.lossyScale.x;
    public bool IsCatched { get; set; }

    #endregion

    #region UNITY_METHODS

    private void Update()
    {
        if (IsCatched)
            return;

        if (!IsInitialized)
            return;

        _walkBehaviour?.OnUpdate();
        _currentTime += Time.deltaTime;
        if (_currentTime >= 1)
        {
            _currentTime = 0;
            _walkBehaviour?.OnRareUpdate();
        }
    }

    #endregion

    #region METHODS

    public void Initialize()
    {
        IsCatched = false;
        _walkBehaviour.Initialize(this);
        IsInitialized = true;
    }

    public void CleanUp()
    {
        IsInitialized = false;
    }

    #endregion
}
