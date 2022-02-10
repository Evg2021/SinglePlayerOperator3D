using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform Capsule;

    public float mouseSensitivity = 100f;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // для поворота влево и вправо с помощью мыши
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // ограничение вращения вверх и вниз на 90градусов

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // вращение вверх и вниз

        Capsule.Rotate(Vector3.up * mouseX);
    }
}
