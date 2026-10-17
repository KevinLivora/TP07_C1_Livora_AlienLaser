using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.15f;
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 10f;

    private Vector3 velocity;
    private float fixedY;
    private float fixedZ;

    private void Awake()
    {
        fixedY = transform.position.y;
        fixedZ = transform.position.z;
    }

    private void LateUpdate()
    {
        float desiredX = Mathf.Clamp(target.position.x, minX, maxX);
        Vector3 desiredPosition = new Vector3(desiredX, fixedY, fixedZ);

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
    }
}