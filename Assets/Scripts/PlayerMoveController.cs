using UnityEngine;
using System.Collections;

public class PlayerMoveController : MonoBehaviour {
	[SerializeField]
	private float maxSpeed = 10f;
	[SerializeField]
	private float jumpForce = 700f;
	[SerializeField]
	private bool isFacingRight = true;
	private bool isGrounded = true;
	private float distToGround;

	private Rigidbody playerRigidBody;
	private Animator playerAnimatior;

	void Start () {
		playerRigidBody = GetComponent<Rigidbody> ();
		playerAnimatior = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		CheckGrounded ();
		Move ();
	}

	void Update(){
		if (isGrounded && Input.GetKeyDown (KeyCode.W))
			Jump ();
	}

	void Flip(){
		isFacingRight = !isFacingRight;
		transform.Rotate(new Vector3(0, 180, 0));
	}

	void Move(){
		float move = Input.GetAxis ("Horizontal");

		playerAnimatior.SetFloat ("horizontalSpeed", Mathf.Abs (move));	
		playerRigidBody.velocity = new Vector3 (move * maxSpeed, playerRigidBody.velocity.y, playerRigidBody.velocity.z);

		if (move > 0 && !isFacingRight)
			Flip ();
		else if (move < 0 && isFacingRight)
			Flip ();
	}

	void CheckGrounded (){
		isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround);
		playerAnimatior.SetBool ("grounded", isGrounded);	
		playerAnimatior.SetFloat ("verticalSpeed", playerRigidBody.velocity.y);	
	}

	void Jump(){
		playerAnimatior.SetBool ("grounded", false);	
		playerRigidBody.AddForce (new Vector3(0, jumpForce, 0));
	}


}
