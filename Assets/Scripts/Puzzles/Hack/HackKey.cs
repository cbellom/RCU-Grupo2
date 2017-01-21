using UnityEngine;
using UnityEngine.UI;
using System;

public class HackKey : MonoBehaviour{
	public KeyCode key;

	public Action<HackKey> TriggerStay
	{
		get;
		set;
	}

	public Action<HackKey> TriggerExit
	{
		get;
		set;
	}

	private Image image;
    
	public void SetUp(KeyCode key){
		this.key = key;
		SetUpImageSprite ();
	}

	private void SetUpImageSprite(){
        image = GetComponent<Image>();

		if (key == KeyCode.UpArrow)
			image.rectTransform.rotation = Vector3.up;
		else if (key == KeyCode.DownArrow)
			image.rectTransform.rotation = Vector3.down;
		else if (key == KeyCode.LeftArrow)
			image.rectTransform.rotation = Vector3.left;
		else 
			image.rectTransform.rotation = Vector3.right;
	}

	private void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.CompareTag ("PuzzleHack") && Input.GetKey(key))
        {
            Destroy(gameObject);
            if (TriggerStay != null) TriggerStay(this);
        }
			
	}

	private void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("PuzzleHack"))
			if(TriggerExit  != null)TriggerExit (this);
	}
}
