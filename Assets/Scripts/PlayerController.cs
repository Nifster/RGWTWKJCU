using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int PlayerNo;
	public float speed;

	private Rigidbody2D rb2d;
	private Vector2 prevMovement;
	private string horzAxis, vertAxis;
	private string attackAnimName;
	private KeyCode upKey, downKey, leftKey, rightKey, attackKey;
	private Animator animator;

	private GameObject sword;

	void Start () {

		sword = this.GetComponent<GameObject> ();
		animator = this.GetComponent<Animator> ();

		rb2d = GetComponent<Rigidbody2D> ();
		if (PlayerNo == 2) {
			horzAxis = "HorizontalP2";
			vertAxis = "VerticalP2";
			upKey = KeyCode.UpArrow;
			downKey = KeyCode.DownArrow;
			leftKey = KeyCode.LeftArrow;
			rightKey = KeyCode.RightArrow;
			attackKey = KeyCode.Keypad1;
			attackAnimName = "player2_attack";
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

		sword.SetActive (false);

	}

	void Update () {

		if (Input.GetKey (upKey) || Input.GetKey (downKey) || Input.GetKey (leftKey) || Input.GetKey (rightKey)) {
			animator.SetBool ("isMoving", true);
		} else {
			animator.SetBool ("isMoving", false);
		}

		if (Input.GetKeyDown (attackKey)) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}

		if (AnimatorIsPlaying (attackAnimName)) {
			sword.SetActive (true);
		} else {
			sword.SetActive (false);
		}


	}

	void FixedUpdate () {

		float moveHorizontal = Input.GetAxis (horzAxis);
		float moveVertical = Input.GetAxis (vertAxis);

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		rb2d.AddForce (movement * speed);

	}


	bool AnimatorIsPlaying(){
		return animator.GetCurrentAnimatorStateInfo(0).length > animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
	}

	bool AnimatorIsPlaying(string stateName){
		return AnimatorIsPlaying() && animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
	}