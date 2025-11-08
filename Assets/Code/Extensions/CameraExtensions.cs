using UnityEngine;

public static class CameraExtensions
{
    public static Vector3 GetRandomVisiblePosition(this Camera camera, float offset = 0f)
    {
        if (camera == null)
            return Vector3.zero;

        float halfHeight = camera.orthographicSize;
        float halfWidth = halfHeight * camera.aspect;

        Vector3 camPos = camera.transform.position;

        float minX = camPos.x - halfWidth + offset;
        float maxX = camPos.x + halfWidth - offset;
        float minY = camPos.y - halfHeight + offset;
        float maxY = camPos.y + halfHeight - offset;

        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        return new Vector3(x, y, 0);
    }
}
