using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    CharacterController characterController;
    [SerializeField] private float mouseSensivity = 1f;
    [SerializeField] float MouseYrotation, MouseXrotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movment();
        MouseRotation();
        Fire();
    }

    private void Movment()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * speed;
        velocity = transform.TransformDirection(velocity);
        characterController.SimpleMove(velocity);
    }

    private void MouseRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        MouseXrotation += mouseX * mouseSensivity;
        float mouseY = Input.GetAxis("Mouse Y");
        MouseYrotation -= mouseY * mouseSensivity;

        MouseYrotation = ClampAngle(MouseYrotation, -89, 89);

        Camera.main.transform.rotation = Quaternion.Euler(MouseYrotation, MouseXrotation, 0);
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

    private void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
            if (Physics.Raycast(ray, out RaycastHit hitinfo, Mathf.Infinity))
            {
                Debug.Log(hitinfo.transform.name);
                if (hitinfo.transform.CompareTag("Target"))
                {
                    hitinfo.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
        }
    }
}
