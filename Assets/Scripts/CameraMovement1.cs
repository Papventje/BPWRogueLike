using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement1 : MonoBehaviour
{
    public float sensitivity = 2;
    private float rotation;

    Transform playerBody;

    private float xRotation;

    void Start()
    {
        playerBody = gameObject.transform.parent;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, rotation);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
