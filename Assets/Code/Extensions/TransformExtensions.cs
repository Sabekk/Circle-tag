using UnityEngine;

public static class TransformExtensions
{
    public static Vector3 GetPositionClampedToCamera(this Transform transform, Camera camera, float offset)
    {
        Vector3 clampedPosition = transform.position;
        if (!camera)
            return clampedPosition;

        float halfHeight = camera.orthographicSize;
        float halfWidth = halfHeight * camera.aspect;

        Vector3 camPos = camera.transform.position;

        float minX = camPos.x - halfWidth + offset;
        float maxX = camPos.x + halfWidth - offset;
        float minY = camPos.y - halfHeight + offset;
        float maxY = camPos.y + halfHeight - offset;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        clampedPosition = pos;

        return clampedPosition;
    }

    public static Vector3 GetPositionClampedToCamera(this Vector3 position, Camera camera, float offset)
    {
        Vector3 clampedPosition = position;
        if (!camera)
            return clampedPosition;

        float halfHeight = camera.orthographicSize;
        float halfWidth = halfHeight * camera.aspect;

        Vector3 camPos = camera.transform.position;

        float minX = camPos.x - halfWidth + offset;
        float maxX = camPos.x + halfWidth - offset;
        float minY = camPos.y - halfHeight + offset;
        float maxY = camPos.y + halfHeight - offset;

        Vector3 pos = position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        clampedPosition = pos;

        return clampedPosition;
    }

    public static Vector2 GetPositionClampedToCamera(this Vector2 position, Camera camera, float offset)
    {
        return GetPositionClampedToCamera(new Vector3(position.x, position.y, 0), camera, offset);
    }
}
