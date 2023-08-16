using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float laserLifeTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, laserLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
