using UnityEngine;
using System.Collections;

public class MediumEnemyController : EasyEnemyController {

    private bool hasArmor = true;

    protected new void FixedUpdate()
    {
        if (!beingKnockedBack)
        {
            base.FixedUpdate();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Sword")
        {
            if (hasArmor)
            {
                knockedBack();
                hasArmor = false;
                GetComponent<Animator>().SetBool("isHit", true);
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

}
