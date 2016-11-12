using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameObject healthPanel;
    public GameObject healthPrefab;

    public int health;
    public GameObject gameOverPanel;

    public GameObject player1;
    public GameObject player2;
   


    // Use this for initialization
    void Start () {
        
        instance = this;
        for (int i = 0; i < health; i++)
        {
            GameObject newHealth = Instantiate(healthPrefab);
            newHealth.transform.SetParent(healthPanel.transform);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("main");
    }

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("main");
        }
	}
    public void LoseHealth()
    {
        if (health > 0)
        {
            Destroy(healthPanel.transform.GetChild(health - 1).gameObject);
            health--;
            if(health <= 0)
            {
                gameOverPanel.SetActive(true);
                Debug.Log("Game Over");
            } else
            {
                player1.GetComponent<PlayerController>().goInvincible();
                player2.GetComponent<PlayerController>().goInvincible();
            }
        }
        else
        {
            //Game over
            gameOverPanel.SetActive(true);
            Debug.Log("Game Over");
        }
        
    }
}
