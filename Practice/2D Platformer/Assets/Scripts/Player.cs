using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Floats
	public float maxSpeed = 3f;
	public float speed = 50f;
	public float jumpPower = 150f;

	// Booleans
	public bool grounded;
	public bool canDoubleJump;

	// References 
	private Rigidbody2D rb2d;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("Grounded", grounded);
		anim.SetFloat ("Speed", Mathf.Abs(rb2d.velocity.x));

		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.localScale = new Vector3 (1, 1, 1);
		}

		if (Input.GetButton("Jump")) {
			if (grounded) {
				rb2d.AddForce (Vector2.up * jumpPower);
				canDoubleJump = true;
			} else {
				if (canDoubleJump) {
					canDoubleJump = false;
					rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
					rb2d.AddForce (Vector2.up * jumpPower / 1.75f);
				}
			}
		}
	}

	void FixedUpdate() {
		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.x *= 0.75f;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;

		float h = Input.GetAxis ("Horizontal");

		// Fake friction / easing the x speed of our player
		if (grounded) {
			rb2d.velocity = easeVelocity;
		}

		// Moving the player
		rb2d.AddForce ((Vector2.right * speed) * h);

		// Limiting the player's max speed
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		} 
		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		} 
	}
}
