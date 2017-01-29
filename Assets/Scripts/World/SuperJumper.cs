using UnityEngine;
using System.Collections;

public class SuperJumper : MonoBehaviour {

	public float multiplier = 2;

	void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Player")
		{
			other.gameObject.GetComponent<CharacterMoveController>().ReceiveForce(Vector3.up*multiplier);
		}
	}

}
