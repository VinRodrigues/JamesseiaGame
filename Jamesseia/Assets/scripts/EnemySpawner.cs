using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;
    

    [SerializeField]
    private float swarmerInterval = 3.5f;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(9.62f, 7.15f), Random.Range(-1.55f, -3f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}