using UnityEngine;
using System.Collections;

public class CinematicsController : MonoBehaviour {

	public Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();
		if (animator == null)
			Debug.LogError ("CinematicsController require an animator component");
	}

	public void PlayCinematic ( int number) {
		animator.SetInteger ("number", number);
	}
	public void StopCinematic () {
		animator.SetInteger ("number", 0);
	}

}
