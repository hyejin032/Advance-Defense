using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    public GameObject player;

    public float minX = -7f; // 카메라 이동 최소 x
    public float maxX = 7f;  // 카메라 이동 최대 x

    private void Update()
    {
        Vector3 dir = player.transform.position - transform.position;

        // x축 방향 이동 벡터 계산
        float moveX = dir.x * cameraSpeed * Time.deltaTime;

        // 새 위치 계산
        float newX = transform.position.x + moveX;

        // 범위 제한
        newX = Mathf.Clamp(newX, minX, maxX);

        // 위치 적용 (y,z는 고정)
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
