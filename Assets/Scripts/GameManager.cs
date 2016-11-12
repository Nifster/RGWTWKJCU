using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameObject healthPanel;
    public GameObject healthPrefab;

    public int health;

   


    // Use this for initialization
    void Start () {
        
        instance = this;
        for (int i = 0; i < health; i++)
        {
            GameObject newHealth = Instantiate(healthPrefab);
            newHealth.transform.SetParent(healthPanel.transform);
        }
    }

	
	// Update is called once per frame
	void Update () {
	
	}
    public void LoseHealth()
    {
        if (health > 0)
        {
            Destroy(healthPanel.transform.GetChild(health - 1).gameObject);
            health--;
            if(health <= 0)
            {
                Debug.Log("Game Over");
            }
        }
        else
        {
            //Game over
            Debug.Log("Game Over");
        }
        
    }
}
