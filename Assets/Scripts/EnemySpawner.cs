using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{

    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private float spawnRate = 10f;

                    // Start is called before the first frame update
    void Start(){
        StartCoroutine(spawnEnemy(spawnRate, enemy));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        spawnRate= spawnRate - 3;
        if(spawnRate <=1){spawnRate = 1;}

        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-2f, 2), Random.Range(-2f, 2f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(spawnRate, enemy));
    }
}
