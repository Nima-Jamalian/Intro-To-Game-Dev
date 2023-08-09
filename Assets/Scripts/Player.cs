using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 direction;
    [SerializeField] private GameObject laser;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    private void Movement()
    {
        /*
        * Directions
        * UP = 0,1,0
        * Down = 0,-1,0
        * Right = 1,0,0
        * Left = -1,0,0
        */
        float horizantalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        direction = new Vector3(horizantalInput, verticalInput, 0);
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void Shooting()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            laser.SetActive(true);
        }
    }
}
