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

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Sword") && (hasArmor))
        {
            Vector3 dist = transform.position - other.gameObject.transform.position;
            // knockback
            rigidBody.velocity = -rigidBody.velocity.normalized * knockback;
            beingKnockedBack = true;
            Invoke("endKnockback", 1.0f);
            hasArmor = false;
        } else if ((other.tag == "Bullet") && (!hasArmor))
        {
            other.gameObject.GetComponent<Bullet>().Deactivate();
            Destroy(gameObject);
        } else if (other.tag == "Player")
        {
            //TODO
            Destroy(gameObject);
        }
    }

    void endKnockback()
    {
        beingKnockedBack = false;
    }
}
