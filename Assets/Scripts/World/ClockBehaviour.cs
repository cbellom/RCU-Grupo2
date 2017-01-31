using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClockBehaviour : MonoBehaviour {


	public Text clockText;

	private float seconds;
	private float time;

	void Start(){
		clockText.text = "00:00";
		time = Time.time;
	}

	void Update(){
		if (Time.time - time > 1) {
			seconds += 1;
			time = Time.time;
			if (seconds < 10)
				clockText.text = "00:0" + seconds.ToString ();
			else
				clockText.text = "00:" + seconds.ToString ();
		}
	}
}
