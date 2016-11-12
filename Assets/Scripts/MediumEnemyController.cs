using UnityEngine;
using System.Collections;

public class MediumEnemyController : EasyEnemyController {

    public float knockback;

    private bool hasArmor = true;
    private bool beingKnockedBack = false;

    protected new void FixedUpdate()
    {
        if (!beingKnockedBack)
        {
            base.FixedUpdate();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //TODO
            GameManager.instance.LoseHealth();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Sword")
        {
            if (hasArmor)
            {
                Vector3 dist = transform.position - other.gameObject.transform.position;
                // knockback
                rigidBody.velocity = -rigidBody.velocity.normalized * knockback;
                beingKnockedBack = true;
                Invoke("endKnockback", 1.0f);
                hasArmor = false;
            }
            else
            {
                Destroy(gameObject);
            }
        } else if (other.gameObject.tag == "Bullet")
        {
            if (!hasArmor)
            {
                Destroy(gameObject);
            }
            other.gameObject.GetComponent<Bullet>().Deactivate();
        }
    }

    void endKnockback()
    {
        beingKnockedBack = false;
    }
}
