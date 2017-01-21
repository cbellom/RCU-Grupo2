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
	#region Public Methods ----
	public void Activate(){
		//if (active == false) {
			Debug.Log ("animando");
		//	active = true;
			GetComponent<Animator> ().SetInteger ("active", 1);
		//}
	}

	#endregion Public Methods  ----
}
