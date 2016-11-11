using UnityEngine;
using System.Collections;

public class EasyEnemyController : MonoBehaviour {

    public float speed;

    // screen coordinates
    public float bottom;
    public float left;
    public float width;
    public float height;

    static public GameObject target;

    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        Vector2 startPos = new Vector2(left + (Random.value < 0.5 ? 0 : width), bottom + height * Random.value);
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
            return;
        } else if (other.tag == "Player")
        {
            //TODO
            return;
        }
    }
}
