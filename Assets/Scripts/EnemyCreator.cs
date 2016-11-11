using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour {
    public float spawnTime = 5f;        // The amount of time between each spawn.
    public float spawnDelay = 2f;       // The amount of time before spawning starts.

    public GameObject player1;
    public GameObject player2;
    public GameObject easyEnemy;
    public GameObject mediumEnemy;

    void Start()
    {
        // Start calling the Spawn function repeatedly after a delay .
        InvokeRepeating("SpawnEasy", spawnDelay, spawnTime);
        InvokeRepeating("SpawnMedium", spawnTime*4, spawnTime);
    }

    void Spawn(GameObject enemy)
    {
        Instantiate(enemy).GetComponent<EasyEnemyController>().target = player1;
        Instantiate(enemy).GetComponent<EasyEnemyController>().target = player2;
    }

    void SpawnEasy()
    {
        Spawn(easyEnemy);
    }

    void SpawnMedium()
    {
        Spawn(mediumEnemy);
    }
}
