using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    GameManager gameManager;
    UIManager uIManager;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name + " hit me!!!");

        if (collision.CompareTag("Laser")){
            gameManager.score++;
            uIManager.UpdateScoreUI(gameManager.score);
            animator.SetBool("IsEnemeyAlive", false);
            Destroy(gameObject,1f);
        }
    }

}
