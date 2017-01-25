using UnityEngine;
using System.Collections;

public class SuperJumper : MonoBehaviour {

	public float multiplier = 2;

	void OnTriggerEnter (Collider other)
	{
        //Debug.Log(other.name);
		if(other.name == "Player")
		{
			//other.gameObject.GetComponent<CharacterMoveController>().jumpForce(multiplier);
			//other.gameObject.GetComponent<CharacterMoveController>().SuperJump(multiplier);
			CharacterMoveController cmc = other.gameObject.GetComponent<CharacterMoveController> ();
			cmc.ReceiveForce(new Vector3(0,multiplier,0 ));
		}
	}

    /*void OnCollisionEnter(Collision collision){
		Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "Player")
        {
			CharacterMoveController cmc = collision.gameObject.GetComponent<CharacterMoveController> ();
			cmc.ReceiveForce(new Vector3(0,multiplier,0 ));
        }
    }*/
}
