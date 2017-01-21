using UnityEngine;
using UnityEngine.UI;
using System;

public class HackKey : MonoBehaviour{
	public KeyCode key;

	public Action<HackKey> TriggerEnter
	{
		get;
		set;
	}

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
			gameObject.GetComponent<RectTransform> ().Rotate (new Vector3 (0, 0, 0));
		else if (key == KeyCode.DownArrow)
			gameObject.GetComponent<RectTransform> ().Rotate (new Vector3 (0, 0, 180));
		else if (key == KeyCode.LeftArrow)
			gameObject.GetComponent<RectTransform> ().Rotate (new Vector3 (0, 0, 90));
		else
			gameObject.GetComponent<RectTransform> ().Rotate (new Vector3 (0, 0, -90));
	}

	private void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("PuzzleHack") && key == KeyCode.Escape) {
			if (TriggerEnter != null)
				TriggerEnter (this);
		}

	}

	private void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.CompareTag ("PuzzleHack") && Input.GetKey(key))
        {
			gameObject.GetComponent<Image> ().enabled = false;
			gameObject.GetComponent<Collider2D> ().enabled = false;
            if (TriggerStay != null) TriggerStay(this);
        }
			
	}

	private void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("PuzzleHack"))
			if(TriggerExit  != null)TriggerExit (this);
	}
}
