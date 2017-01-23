using UnityEngine;
using System.Collections;

public class RotationalPlatform : MonoBehaviour {

	public bool active =false;
	private Animator smachine;

	void Start(){
		smachine =	GetComponent<Animator> ();
	}

	void Update(){
		if (smachine.GetInteger ("active") == 1) {
			GetComponent<Animator> ().SetInteger ("active", 2);
		}
	}

	public void Activate(){
		GetComponent<Animator> ().SetInteger ("active", 1);
	}
}
