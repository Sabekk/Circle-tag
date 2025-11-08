using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkBehaviour : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private float walkSpeed = 2;
    [SerializeField] private float runSpeed = 2;
    [SerializeField] private float turnSpeed = 5;
    [SerializeField] private float directionChangeTime = 2f;

    [SerializeField] private float detectionRadius = 1f;
    [SerializeField] private LayerMask detectionMask;

    private Vector2 _currentDir;
    private Vector2 _targetDir;
    private float _changeDirTimer;

    private readonly List<IChasable> _nearbyChasables = new();

    #endregion

    #region PROPERTIES

    public Enemy Enemy { get; set; }

    #endregion

    #region METHODS

    public void Initialize(Enemy enemy)
    {
        Enemy = enemy;

        _currentDir = Random.insideUnitCircle.normalized;
        _targetDir = _currentDir;
        _changeDirTimer = directionChangeTime;
    }

    public void OnUpdate()
    {
        if (Enemy.IsCatched)
            return;

        if (!Enemy.IsInitialized)
            return;

        float delta = Time.deltaTime;
        Vector2 pos = transform.position;

        Vector2 runDir = Vector2.zero;
        bool shouldRun = false;

        foreach (var chasable in _nearbyChasables)
        {
            if (chasable == null)
                continue;

            if (chasable.ChasingTransform == null)
                continue;

            Vector2 targetPos = chasable.ChasingTransform.position;
            Vector2 away = pos - targetPos;

            float dist = away.magnitude;

            if (dist > 0.001f)
            {
                runDir += away / dist;
                shouldRun = true;
            }
        }

        if (shouldRun)
            _targetDir = runDir.normalized;
        else
        {
            _changeDirTimer -= delta;
            if (_changeDirTimer <= 0f)
            {
                _targetDir = Random.insideUnitCircle.normalized;
                _changeDirTimer = directionChangeTime;
            }
        }

        _currentDir = Vector2.Lerp(_currentDir, _targetDir, delta * turnSpeed).normalized;

        float speed = shouldRun ? runSpeed : walkSpeed;
        pos += _currentDir * speed * delta;
        transform.position = pos.GetPositionClampedToCamera(Camera.main, Enemy.CircleRadius);

        if (_currentDir.sqrMagnitude > 0.001f)
        {
            float ang = Mathf.Atan2(_currentDir.y, _currentDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(ang - 90f, Vector3.forward);
        }
    }

    public void OnRareUpdate()
    {
        if (Enemy.IsCatched)
            return;

        if (!Enemy.IsInitialized)
            return;

        CheckNearbyChasables();
    }

    private void CheckNearbyChasables()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius, detectionMask);

        _nearbyChasables.Clear();

        foreach (var hit in hits)
        {
            if (!hit)
                continue;

            var chasable = hit.GetComponent<IChasable>();
            if (chasable != null)
                _nearbyChasables.Add(chasable);
        }
    }

    #endregion
}
