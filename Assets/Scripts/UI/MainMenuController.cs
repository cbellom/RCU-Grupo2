using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : CanvasUI {
   	
	public CanvasUI fadeCanvas;

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
			yield return new WaitForSeconds(1);
		}

		yield return new WaitForSeconds(seconds);

		isTurnOn = true;
		SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
	}

	private void HanldeOnKeyPressed(){
		isTurnOn = true;
	}

	private void GetStartInput(){
		if (Input.GetButton ("Start")) {
			ChangeScene ("1_Tutorial");
		}
		
	}
}
