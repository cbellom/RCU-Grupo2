using UnityEngine;
using System.Collections;

public class SuperJumper : MonoBehaviour {

	public float multiplier = 2;

	/*void OnTriggerEnter (Collider other)
	{
        //Debug.Log(other.name);
		if(other.name == "Player")
		{
			other.gameObject.GetComponent<CharacterMoveController>().jumpForce(multiplier);
		}
	}*/

    /*void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<CharacterMoveController>().SuperJump(multiplier);
        }
    }*/
}
