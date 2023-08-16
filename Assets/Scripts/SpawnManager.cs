using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float enemySpawnRate = 4f;
    [SerializeField] private GameObject enemySpawnPointRight,enemySpawnPointLeft;
    [SerializeField] private float generateRandomNumber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        generateRandomNumber = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(enemySpawnPointLeft.transform.position.x,enemySpawnPointRight.transform.position.x),enemySpawnPointRight.transform.position.y,enemySpawnPointRight.transform.position.z),Quaternion.identity);
            yield return new WaitForSeconds(enemySpawnRate);
        }

    }
}
