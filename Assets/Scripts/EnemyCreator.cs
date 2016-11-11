using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour {
    public float spawnTime = 5f;        // The amount of time between each spawn.
    public float spawnDelay = 3f;       // The amount of time before spawning starts.

    public GameObject player;
    public GameObject easyEnemy;

    void Start()
    {
        // Start calling the Spawn function repeatedly after a delay .
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
        EasyEnemyController.target = player;
    }


    void Spawn()
    {
        Instantiate(easyEnemy);
    }

}
