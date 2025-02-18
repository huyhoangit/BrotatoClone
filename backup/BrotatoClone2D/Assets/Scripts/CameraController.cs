using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private float smoothSpeed = 5f;

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
