using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public GameObject player;

	public float xMin, xMax, yMin, yMax;

	private Vector3 offset;

	void Start () {
		offset = transform.position - player.transform.position;
	}

	void LateUpdate () {

		Vector3 pos = player.transform.position + offset;

		transform.position = new Vector3 (
			Mathf.Clamp (pos.x, xMin, xMax),
			Mathf.Clamp (pos.y, yMin, yMax),
			pos.z
		);
	}
}
