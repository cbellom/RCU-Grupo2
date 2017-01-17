using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
[RequireComponent (typeof (CharacterController))]
public class CharacterMoveController : MonoBehaviour {

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private float horizontalInput = 0;
    private float verticalInput = 0;

	private Vector3 moveDirection = Vector3.zero;
	private Vector3 movement = Vector3.zero;
	private Vector3 forward = Vector3.zero;
	private Vector3 right = Vector3.zero;
	private Vector3 targetDirection = Vector3.zero;

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
        if (controller.isGrounded) {
			Move ();

			if (Input.GetButton ("Jump"))
				Jump ();

        }
		movement.y -= gravity * Time.deltaTime;
		controller.Move(movement * Time.deltaTime);
    }

	void Move(){
		forward = transform.forward;
		right = transform.right;

		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");

		targetDirection = horizontalInput * right + verticalInput * forward;
		Rotate ();
		MoveForward ();

		playerAnimatior.SetFloat ("moveSpeed", controller.velocity.magnitude);	
	}

	void Rotate(){
		if(targetDirection != Vector3.zero)
			transform.rotation = Quaternion.LookRotation (moveDirection);
	}

	void MoveForward(){
		moveDirection = Vector3.RotateTowards (moveDirection, targetDirection, 100 * Mathf.Deg2Rad * Time.deltaTime, 1000);
		movement = moveDirection * speed;
	}

	void CheckGrounded (){
		playerAnimatior.SetBool ("grounded", controller.isGrounded);	
		playerAnimatior.SetFloat ("verticalSpeed", controller.velocity.y);
	}

	void Jump(){
		playerAnimatior.SetBool ("grounded", false);	
		movement.y = jumpSpeed;
	}
}
