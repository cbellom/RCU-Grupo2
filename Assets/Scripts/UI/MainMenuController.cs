using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : CanvasUI {
   
	void Start(){
		OnKeyPressed += HanldeOnKeyPressed;
	}

    public void ChangeScene(string sceneName) {
        Debug.Log("Load scene " + sceneName);
		StartCoroutine(LoadOtherScene(sceneName, fadeSpeed));
    }

	private IEnumerator LoadOtherScene(string sceneName, float seconds)    {
		isTurnOn = false;

		yield return new WaitForSeconds(seconds);
		isTurnOn = true;
		SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
	}

	private void HanldeOnKeyPressed(){
		isTurnOn = true;
	}
}
