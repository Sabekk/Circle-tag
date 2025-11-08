using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, ICatchable
{
    #region VARIABLES

    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] private EnemyWalkBehaviour _walkBehaviour;

    [SerializeField] private SpriteRenderer _characterIcon;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _catchedColor;

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
        _characterIcon.color = _defaultColor;
        IsCatched = false;
        _walkBehaviour.Initialize(this);
        IsInitialized = true;
    }

    public void CleanUp()
    {
        IsInitialized = false;
    }

    public void OnChatched()
    {
        IsCatched = true;
        _characterIcon.color = _catchedColor;
    }

    #endregion
}
