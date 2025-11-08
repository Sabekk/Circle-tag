using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private CircleCollider2D _circleCollider;

    #endregion

    #region PROPERTIES

    public float CircleRadius => _circleCollider.radius * transform.lossyScale.x;

    #endregion

    #region METHODS

    public void Initialize()
    {

    }

    public void CleanUp()
    {

    }

    #endregion
}
