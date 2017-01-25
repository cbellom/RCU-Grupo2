using UnityEngine;
using System.Collections;

public class CharacterMoveController : MonoBehaviour {
	
	[SerializeField] float movementSpeed = 5.0f;	//La velocidad del Jugador	
	[SerializeField] float turnSpeed = 1000f;		//La velocidad de giro del jugador
	[SerializeField] float jumpForce = 6f;			//Fuerza de salto del jugador
	[SerializeField] LayerMask whatIsGround;		

	Animator anim;
	public Rigidbody rigidBody;
	Vector3 playerInput;
	bool grounded = true;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		if (IsGrounded())
			grounded = true;
		else
			grounded = false;

		/*if (/*GameManager.instance != null && GameManager.instance.IsGameOver ()) 
		{
			anim.SetFloat ("Speed", 0f);
			return;
		}*/
		Vector3 direccion = new Vector3();
		direccion.x = Input.GetAxis("Vertical")*(-transform.position.x)+Input.GetAxis ("Horizontal")*(-transform.position.z);
		direccion.z = Input.GetAxis("Vertical")*(-transform.position.z)+Input.GetAxis ("Horizontal")*(transform.position.x);

		playerInput.Set(direccion.x, 0f, direccion.z);

		anim.SetFloat ("Speed", playerInput.sqrMagnitude);

		if (playerInput == Vector3.zero)
			return;

		Vector3 newPosition = transform.position + playerInput.normalized * movementSpeed * Time.deltaTime;

		rigidBody.MovePosition (newPosition);

		Quaternion newRotation = Quaternion.LookRotation (playerInput);  

		if(rigidBody.rotation != newRotation) 
			rigidBody.rotation = Quaternion.RotateTowards(rigidBody.rotation, newRotation, turnSpeed * Time.deltaTime);
	}

    void Update()    {
		if (Input.GetButtonDown ("Jump") && grounded) 
		{
			rigidBody.AddForce (new Vector3 (0f, jumpForce, 0f), ForceMode.Impulse);
			anim.SetTrigger ("Jump");
			grounded = false;
			Debug.Log ("aasdas");
		}

		anim.SetBool ("Grounded", grounded);

	}

	bool IsGrounded(){
		return Physics.Raycast(transform.position, -Vector3.up, 0.3f);
	}



	public void ReceiveForce(Vector3 force){
		Debug.Log ("fuerza");
		rigidBody.AddForce (new Vector3 (force.x, force.y, force.z), ForceMode.Impulse);
		anim.SetTrigger ("Jump");
		grounded = false;
	}


}
