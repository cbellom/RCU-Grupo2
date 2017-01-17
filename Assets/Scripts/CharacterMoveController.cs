using UnityEngine;
using System.Collections;

public class CharacterMoveController : MonoBehaviour {

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private float xMove = 0;
    private float zMove = 0;
    private Vector3 moveDirection = Vector3.zero;


    [SerializeField]
    private Vector3 radius = new Vector3(5, 0, 0);
    private float currentRotation = 0.0f;
    private Quaternion rotation;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            xMove = Input.GetAxis("Horizontal");
            currentRotation += xMove * Time.deltaTime * speed;
            
            rotation.eulerAngles = new Vector3(0, -currentRotation, 0);
            transform.rotation = rotation;

            moveDirection = new Vector3(xMove, 0, zMove);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            transform.rotation = rotation;

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
