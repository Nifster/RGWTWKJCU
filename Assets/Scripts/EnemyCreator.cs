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
        EasyEnemyController.speed = 10;
        // Start calling the Spawn function repeatedly after a delay .
        InvokeRepeating("SpawnEasy", spawnDelay, spawnTime);
        InvokeRepeating("SpawnMedium", spawnTime*4, spawnTime);
    }

    void Spawn(GameObject enemy)
    {
        EasyEnemyController enemy1 = Instantiate(enemy).GetComponent<EasyEnemyController>();
        enemy1.target = player1;
        enemy1.start_x = -5;
        EasyEnemyController enemy2 = Instantiate(enemy).GetComponent<EasyEnemyController>();
        enemy2.target = player2;
        enemy2.start_x = 5;
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
