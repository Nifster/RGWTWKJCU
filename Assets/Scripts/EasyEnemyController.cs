using UnityEngine;
using System.Collections;

public class EasyEnemyController : MonoBehaviour {

    public static float speed;

    // screen coordinates
    public float bottom;
    public float height;
    public float start_x;

    public GameObject target;

    protected Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        Vector2 startPos = new Vector2(start_x, bottom + height * Random.value);
        transform.position = startPos;
        rigidBody = this.GetComponent<Rigidbody2D>();
    }
	
	protected void FixedUpdate () {
        Vector2 dist = target.transform.position - transform.position;
        rigidBody.AddForce(dist.normalized * speed);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            other.gameObject.GetComponent<Bullet>().Deactivate();
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Sword")
        {
            //TODO
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Player")
        {
            //TODO
            GameManager.instance.LoseHealth();
        }
    }
}
