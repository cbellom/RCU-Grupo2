using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : CanvasUI {
   	
	public CanvasUI fadeCanvas;
	public MenuSoundController msc;
    public SceneLoader sceneLoader;

    void Start(){
		OnKeyPressed += HanldeOnKeyPressed;
		OnFrameUpdated += GetStartInput;
	}
		

    public void ChangeScene(string sceneName) {
		StopAllCoroutines ();
		StartCoroutine(LoadOtherScene(sceneName, fadeSpeed));
    }

	private IEnumerator LoadOtherScene(string sceneName, float seconds)    {
		isTurnOn = false;

		if (fadeCanvas != null) {
			fadeCanvas.TurnOn ();
			msc.FadeSoundMusic ();
		}

		yield return new WaitForSeconds(seconds);

		isTurnOn = true;
        sceneLoader.Load(sceneName);
	}

	private void HanldeOnKeyPressed(){
		isTurnOn = true;
	}

	private void GetStartInput(){
		if (Input.anyKeyDown ) {
			ChangeScene ("1_Tutorial");
		}
		
	}
}
