using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour {
    public float spawnTime = 5f;        // The amount of time between each spawn.
    public float spawnDelay = 3f;       // The amount of time before spawning starts.

    public GameObject player1;
    public GameObject player2;
    public GameObject easyEnemy;

    void Start()
    {
        // Start calling the Spawn function repeatedly after a delay .
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }


    void Spawn()
    {
        Instantiate(easyEnemy).GetComponent<EasyEnemyController>().target = player1;
        Instantiate(easyEnemy).GetComponent<EasyEnemyController>().target = player2;
    }

}
