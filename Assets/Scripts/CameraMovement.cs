using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 2;
    public float rotationIncrease;
    private float rotation;

    [HideInInspector]
    public float xRotation;

    Transform playerBody;

    private void Start()
    {
        playerBody = gameObject.transform.parent;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) && rotation <= 8 || !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && rotation < 0)
        {
            rotation += rotationIncrease * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && rotation >= -8 || !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && rotation > 0)
        {
            rotation -= rotationIncrease * Time.deltaTime;
        }

        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, rotation);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
