using UnityEngine;
using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
[RequireComponent (typeof (CharacterController))]
public class CharacterMoveController : MonoBehaviour {

	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float rotationSpeed = 45f;
	public float gravity = 20.0F;
	public bool isFacingForward = true;

	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
	private Animator playerAnimatior;


	void Start () {
		playerAnimatior = GetComponent<Animator> ();
		controller = GetComponent<CharacterController>();
	}

	void FixedUpdate () {
		CheckGrounded ();
	}

	void Update()    {
		Rotate ();

		if (controller.isGrounded) {
			Move ();

			if (Input.GetButton ("Jump"))
				Jump ();

		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	void Move(){
		MoveForward ();
		playerAnimatior.SetFloat ("moveSpeed", controller.velocity.magnitude);	
	}

	void Rotate(){
		transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);

		if (Input.GetAxis("Vertical") > 0 && !isFacingForward)
			Flip ();
		else if (Input.GetAxis("Vertical") < 0 && isFacingForward)
			Flip ();

		playerAnimatior.SetFloat("horizontalSpeed", Input.GetAxis("Horizontal"));
	}

	void MoveForward(){
		moveDirection = Vector3.forward * Input.GetAxis("Vertical");
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
	}

	void CheckGrounded (){
		playerAnimatior.SetBool ("grounded", controller.isGrounded);	
		playerAnimatior.SetFloat ("verticalSpeed", controller.velocity.y);
	}

	void Jump(){
		playerAnimatior.SetBool ("grounded", false);	
		moveDirection.y = jumpSpeed;
	}

	void Flip(){
		isFacingForward = !isFacingForward;
		playerAnimatior.SetBool ("isFacingForward", isFacingForward);	
	}

	void OnControllerColliderHit(ControllerColliderHit hit){		
		if (hit.gameObject.tag == "AnchorObj"){

			if (hit.moveDirection.y < 0F){
				RotationalPlatform rp = hit.gameObject.GetComponent<RotationalPlatform> ();
				if (rp) {
					rp.Activate ();
				}
			}
		} 
	}

	public void ReceiveForce(Vector3 force){
		moveDirection.x += force.x ;
		moveDirection.y += force.y ;
		moveDirection.z += force.z ;

		controller.Move ( transform.up*0.1f);
		playerAnimatior.SetBool ("grounded", false);	
	}
}