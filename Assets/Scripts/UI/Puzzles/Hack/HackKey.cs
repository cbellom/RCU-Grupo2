using UnityEngine;
using UnityEngine.UI;
using System;

public class HackKey : MonoBehaviour{
	public KeyCode key;
	public Sprite up;
	public Sprite down;
	public Sprite left;
	public Sprite right;

	public Action TriggerStay
	{
		get;
		set;
	}

	public Action TriggerExit
	{
		get;
		set;
	}

	private Image image;

	void Start(){
		image = GetComponent<Image> ();
	}

	void SetUp(KeyCode key){
		this.key = key;
		SetUpImageSprite ();
	}

	private void SetUpImageSprite(){
		if (key == KeyCode.UpArrow)
			image.sprite = up;
		else if (key == KeyCode.DownArrow)
			image.sprite = down;
		else if (key == KeyCode.LeftArrow)
			image.sprite = left;
		else 
			image.sprite = right;
	}

	private void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.CompareTag ("Hack") && Input.GetKey (key))
			if(TriggerStay  != null)TriggerStay ();
	}

	private void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Hack"))
			if(TriggerExit  != null)TriggerExit ();
	}
}
