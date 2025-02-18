using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public Transform player;
    private float smoothSpeed = 5f;

    //private void Start()
    //{
    //    Camera.main.gameObject.SetActive(false);
    //}
    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
