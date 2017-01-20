using UnityEngine;
using System.Collections;

public class EyeController : MonoBehaviour {

	public Animator animator;

	void Start (){
		animator = GetComponent<Animator>();
	}
	void Update (){
		float moveX = Input.GetAxis ("Horizontal");
		animator.SetFloat ("moveOnX", moveX);
	}


}
