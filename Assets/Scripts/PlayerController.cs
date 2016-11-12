using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public static bool isInvincible = false;
    public float invincibleTime;
	public int PlayerNo;
	public float speed;
    public GameObject bulletPrefab;
    public GameObject muzzle;
    
    [SerializeField]
    private float bulletSpeed;

	private Rigidbody2D rb2d;
	private Vector2 prevMovement;
	private string horzAxis, vertAxis;
	private string attackAnimName;
	private KeyCode upKey, downKey, leftKey, rightKey, attackKey, passWeaponKey;
	private Animator animator;

	private GameObject sword;
    private SpriteRenderer spriteRenderer;
    private Vector3 direction = Vector3.left;
    private bool isFacingRight = true;
    public bool hasGun = false;

    void Start () {

        spriteRenderer = GetComponent<SpriteRenderer>();
		sword = this.transform.GetChild (0).gameObject;
		animator = this.GetComponent<Animator> ();

		rb2d = GetComponent<Rigidbody2D> ();
		if (PlayerNo == 2) {
			horzAxis = "HorizontalP2";
			vertAxis = "VerticalP2";
			upKey = KeyCode.UpArrow;
			downKey = KeyCode.DownArrow;
			leftKey = KeyCode.LeftArrow;
			rightKey = KeyCode.RightArrow;
			attackKey = KeyCode.Slash;
			attackAnimName = "player1_attack";
		} else {
			horzAxis = "Horizontal";
			vertAxis = "Vertical";
			upKey = KeyCode.W;
			downKey = KeyCode.S;
			leftKey = KeyCode.A;
			rightKey = KeyCode.D;
			attackKey = KeyCode.F;
			attackAnimName = "player1_attack";
		}

        passWeaponKey = KeyCode.Space;

		sword.SetActive (false);

	}

	void Update () {
        if (hasGun)
        {
            muzzle.SetActive(true);
        }
        else
        {
            muzzle.SetActive(false);
        }

		if (Input.GetKey (upKey) || Input.GetKey (downKey) || Input.GetKey (leftKey) || Input.GetKey (rightKey)) {
			animator.SetBool ("isMoving", true);
		} else {
			animator.SetBool ("isMoving", false);
		}

		if (Input.GetKeyDown (attackKey)) {
            if (hasGun)
            {
                animator.SetBool("isShooting", true);
                Shoot();
            }
            else
            {
                animator.SetBool("isAttacking", true);
                sword.SetActive (true);
                AudioManager.instance.LightsaberSFX();
            }
		}

        if (Input.GetKeyDown(passWeaponKey))
        {
            hasGun = !hasGun;
        }


	}

    void EndAttack()
    {
        animator.SetBool ("isAttacking", false);
        animator.SetBool("isShooting", false);
        sword.SetActive (false);
    }

	void FixedUpdate () {

		float moveHorizontal = Input.GetAxis (horzAxis);
		float moveVertical = Input.GetAxis (vertAxis);

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        if(moveHorizontal< 0)
        {
            transform.localScale=new Vector2(1, 1);
            direction = Vector3.left;
        }
        else if (moveHorizontal > 0)
        {
            transform.localScale = new Vector2(-1, 1);
            direction = Vector3.right;
        }

		rb2d.velocity = (movement * speed);

	}


	bool AnimatorIsPlaying(){
		return ( animator.GetCurrentAnimatorClipInfo (0).Length > animator.GetCurrentAnimatorStateInfo (0).normalizedTime ) ;
	}

	bool AnimatorIsPlaying(string stateName){
		return AnimatorIsPlaying() && animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
	}

    private void Shoot()
    {
        Bullet newBullet = PoolManager.instance.GetBullet();
        newBullet.transform.rotation = transform.rotation;
        newBullet.transform.position = muzzle.transform.position;
        newBullet.GetComponent<Rigidbody2D>().velocity =  (bulletSpeed + speed) *direction;
        AudioManager.instance.ShootSFX();

    }

    public void goInvincible()
    {
       // GetComponent<BoxCollider2D>().enabled = false;
        Invoke("endInvincible", invincibleTime);
        InvokeRepeating("blink", 0f, 0.2f);
    }

    public void blink()
    {
        GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
    }

    private void endInvincible()
    {
      //  GetComponent<BoxCollider2D>().enabled = true;
        CancelInvoke();
        GetComponent<SpriteRenderer>().enabled = true;
    }
    

}