using UnityEngine;
using System.Collections;

public class EasyEnemyController : MonoBehaviour {

    public float speed;

    // screen coordinates
    public float bottom;
    public float height;

    public GameObject target;

    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        Vector2 startPos = new Vector2(0, bottom + height * Random.value);
        transform.position = startPos;
        rigidBody = this.GetComponent<Rigidbody2D>();
    }
	
	void FixedUpdate () {
        Vector2 dist = target.transform.position - transform.position;
        rigidBody.AddForce(dist.normalized * speed);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log("collided with bullet");
            other.gameObject.GetComponent<Bullet>().Deactivate();
            Destroy(gameObject);
        } else if (other.tag == "Sword")
        {
            //TODO
            Destroy(gameObject);
        } else if (other.tag == "Player")
        {
            //TODO
            Destroy(gameObject);
        }
    }
}
