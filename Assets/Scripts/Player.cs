using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 direction;
    [SerializeField] private GameObject laser;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

        if(transform.position.x > 3.72f)
        {
            transform.position = new Vector3(-3.77f, transform.position.y, transform.position.z);
        } else if (transform.position.x < -3.77f)
        {
            transform.position = new Vector3(3.72f, transform.position.y, transform.position.z);
        }

        //Clamp Player Y value between end of screen and center point
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.1f, -1.5f),transform.position.z);
    }

    private void Shooting()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            //laser.SetActive(true);
            Instantiate(laser, transform.position, transform.rotation);
            audioSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
