using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    float gravity = 9.81f;
    [SerializeField] private float mouseSensivity = 1f;
    [SerializeField] float MouseYrotation, MouseXrotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    } 

    // Update is called once per frame
    void Update()
    {
        Movment();
        MouseRotation();
    }

    private void Movment()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 Velocity = direction * speed;
        transform.Translate(Velocity * Time.deltaTime);
    }

    private void MouseRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        MouseXrotation += mouseX * mouseSensivity;
        float mouseY = Input.GetAxis("Mouse Y");
        MouseYrotation -= mouseY * mouseSensivity;

        MouseYrotation = ClampAngle(MouseYrotation, -89, 89);

        Camera.main.transform.localRotation = Quaternion.Euler(MouseYrotation, MouseXrotation, 0);
    }

    private float ClampAngle(float Angle, float min, float max)
    {
        if (Angle < -360f)
        {
            Angle += 360f;
        }
        if (Angle > 360f)
        {
            Angle -= 360f;
        }
        return Mathf.Clamp(Angle, min, max);
    }
}
