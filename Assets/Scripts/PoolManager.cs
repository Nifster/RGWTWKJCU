using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour {

    public static PoolManager instance;
    public List<Bullet> bulletPool;
    public int bulletPoolSize;
    public GameObject bulletPrefab;
    public Vector3 OFFSCREEN = new Vector3(10000,10000);
    public GameObject bulletParent;

	// Use this for initialization
	void Start () {
        instance = this;
        bulletPool = new List<Bullet>();
        for(int i=0; i<bulletPoolSize; i++)
        {
            GameObject newBullet = Instantiate(bulletPrefab) as GameObject;
            newBullet.transform.position = OFFSCREEN;
            bulletPool.Add(newBullet.GetComponent<Bullet>());
            newBullet.GetComponent<Bullet>().isActive = false;
            newBullet.transform.SetParent(bulletParent.transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Bullet GetBullet()
    {
        for(int i=0;i<bulletPool.Count; i++)
        {
            if (!bulletPool[i].isActive)
            {
                bulletPool[i].isActive = true;
                return bulletPool[i];
            }
        }

        //if no inactive bullets left, expand the pool
        GameObject newBullet = Instantiate(bulletPrefab) as GameObject;
        Bullet resultBullet = newBullet.GetComponent<Bullet>();
        bulletPool.Add(resultBullet);
        resultBullet.isActive = true;
        newBullet.transform.SetParent(bulletParent.transform);
        return resultBullet;
    }
}
