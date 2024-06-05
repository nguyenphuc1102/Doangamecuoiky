using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Tham chiếu đến nhân vật
    public float minYPosition = -9.71f; 
    public float maxYPosition = 5f; 
    private Vector3 offset; // Khoảng cách giữa camera và nhân vật

    void Start()
    {
        // Tính toán khoảng cách giữa camera và nhân vật
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Cập nhật vị trí camera theo vị trí của nhân vật
        Vector3 desiredPosition = player.position + offset;

        // Giới hạn vị trí camera chỉ theo trục y
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minYPosition, maxYPosition);

        // Cập nhật vị trí camera
        transform.position = desiredPosition;
    }
}