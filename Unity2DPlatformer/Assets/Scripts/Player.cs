using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(3,5);
	public float jumpSpeed = 5f;
	public bool standing;
	public GameObject ammo;
	public Transform fireMarker;
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		var absVelX = Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x);
		var absVelY = Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.y);
		if (absVelY <= 0.5f) {
			standing = true;
		} else {
			standing = false;
		}
		var forceX = 0f;
		var forceY = 0f;

		if (Input.GetKey ("right")) {
			if (absVelX < maxVelocity.x)
				forceX = speed;
			this.transform.localScale = new Vector3 (1, 1, 1);
			animator.SetInteger ("AnimState", 1);
		} else if (Input.GetKey ("left")) {
			if (absVelX < maxVelocity.x)
				forceX = -speed;
			this.transform.localScale = new Vector3 (-1, 1, 1);
			animator.SetInteger ("AnimState", 1);
		} else {
			animator.SetInteger("AnimState", 0);
		}
		if (Input.GetKeyDown ("up") && standing) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpSpeed);
		}
		if (Input.GetKey ("space") && standing) {
			animator.SetInteger ("AnimState", 2);
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		} else {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (forceX, forceY));
		}
	}

	public void Fire(){
		if (ammo != null) {
			var clone = Instantiate (ammo, fireMarker.position, Quaternion.identity) as GameObject;
			clone.transform.localScale = transform.localScale;
		}
	}
}
