using UnityEngine;

public class MenuSoundController : MonoBehaviour {

	public AudioSource audioMusic;


	private bool sound_switch = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (sound_switch == false){
			audioMusic.volume = audioMusic.volume - Time.deltaTime;
		}	
	}

	public void FadeSoundMusic(){
		sound_switch = false;
	}
}

