using UnityEngine;
using System.Collections;

public class MediumEnemyController : EasyEnemyController {

    public float knockback;

    private bool hasArmor = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Sword") && (hasArmor))
        {
            Vector3 dist = transform.position - other.gameObject.transform.position;
            // knockback
            rigidBody.MovePosition(transform.position + knockback * dist.normalized);
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
}
