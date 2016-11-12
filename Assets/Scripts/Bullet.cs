using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public bool isActive = false;
    private Rigidbody2D rgBody2D;
	// Use this for initialization
	void Start () {
        rgBody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {

        }else
        {

        }
	}

    public void Deactivate()
    {
        rgBody2D.velocity = new Vector2(0, 0) ;
        isActive = false;
        transform.position = new Vector2(1000, 1000); //offscreen
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Background")
        {
            Deactivate();
        }
    }
}
