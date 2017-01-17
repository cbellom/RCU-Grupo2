using UnityEngine;
using System.Collections;

public class CharacterMoveController : MonoBehaviour {

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private float xMove = 0;
    private float zMove = 0;
    private Vector3 moveDirection = Vector3.zero;

	CharacterController controller;
	private Animator playerAnimatior;

	void Start () {
		controller = GetComponent<CharacterController>();
		playerAnimatior = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		CheckGrounded ();
		Move ();
	}

    void Update()    {
        if (controller.isGrounded) {
			Move ();

			if (Input.GetButton ("Jump"))
				moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

	void Move(){
		xMove = Input.GetAxis("Horizontal");
		zMove = Input.GetAxis("Vertical");

		moveDirection = new Vector3(xMove, 0, zMove);
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;

		playerAnimatior.SetFloat ("moveSpeed", Mathf.Abs (zMove));	
	}

	void CheckGrounded (){
		playerAnimatior.SetBool ("grounded", controller.isGrounded);	
		playerAnimatior.SetFloat ("verticalSpeed", controller.velocity.y);
	}

	void Jump(){
		playerAnimatior.SetBool ("grounded", false);	
		moveDirection.y = jumpSpeed;
	}
}
