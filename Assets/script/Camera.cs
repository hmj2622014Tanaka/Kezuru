using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 2.0f;
    [SerializeField] private float upDownRange = 60.0f;
    [SerializeField] Camera playerCamera;

    float verticalRotation = 0;

    private void Start()
    {
        playerCamera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // マウスの移動量を取得
        float mousuX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mousuY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // 上下の回転
        verticalRotation -= mousuY;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // 左右の回転
        transform.parent.Rotate(0, mousuX, 0);
    }
}
