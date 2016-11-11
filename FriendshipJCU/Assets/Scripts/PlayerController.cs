using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int PlayerNo;
	public float speed;

	private Rigidbody2D rb2d;
	private Vector2 prevMovement;
	private string horzAxis, vertAxis;
	private KeyCode upKey, downKey, leftKey, rightKey;
	private Animator animator;

	void Start () {

		animator = this.GetComponent<Animator> ();

		rb2d = GetComponent<Rigidbody2D> ();
		if (PlayerNo == 2) {
			horzAxis = "HorizontalP2";
			vertAxis = "VerticalP2";
			upKey = KeyCode.UpArrow;
			downKey = KeyCode.DownArrow;
			leftKey = KeyCode.LeftArrow;
			rightKey = KeyCode.RightArrow;
		} else {
			horzAxis = "Horizontal";
			vertAxis = "Vertical";
			upKey = KeyCode.W;
			downKey = KeyCode.S;
			leftKey = KeyCode.A;
			rightKey = KeyCode.D;
		}
	}

	void Update () {

		if (Input.GetKeyDown(upKey) || Input.GetKeyDown(downKey) || Input.GetKeyDown(leftKey) || Input.GetKeyDown(rightKey)) {
			animator.SetBool ("isMoving", false);
		} else {
			animator.SetBool ("isMoving", true);
		}

		Debug.Log (animator.GetBool ("isMoving"));

	}

	void FixedUpdate () {

		float moveHorizontal = Input.GetAxis (horzAxis);
		float moveVertical = Input.GetAxis (vertAxis);

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		rb2d.AddForce (movement * speed);

	}
}
