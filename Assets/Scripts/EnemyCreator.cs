using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour {
    public float spawnTime;        // The amount of time between each spawn.
    public float spawnDelay;       // The amount of time before spawning starts.
    public float startMediumTime;

    public GameObject player1;
    public GameObject player2;
    public GameObject easyEnemy;
    public GameObject mediumEnemy;

    void Start()
    {
        EasyEnemyController.speed = 5;
        // Start calling the Spawn function repeatedly after a delay .
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    void SpawnEnemy(GameObject enemy)
    {
        EasyEnemyController enemy1 = Instantiate(enemy).GetComponent<EasyEnemyController>();
        enemy1.target = player1;
        enemy1.start_x = -5;
        EasyEnemyController enemy2 = Instantiate(enemy).GetComponent<EasyEnemyController>();
        enemy2.target = player2;
        enemy2.start_x = 5;
    }

    void Spawn()
    {
        if (Time.time < startMediumTime)
        {
            SpawnEnemy(easyEnemy);
        } else
        {
            if (Random.value < 0.5)
            {
                SpawnEnemy(easyEnemy);
            } else
            {
                SpawnEnemy(mediumEnemy);
            }

        }
    }
}
