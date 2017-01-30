using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinishSceneController : MonoBehaviour {

	public string sceneName;
	public CanvasUI fadeCanvas;

	private void Start() {
		OpenFadeMenu ();
		StopAllCoroutines ();
		StartCoroutine(WaitToEndScene());
	}

	private void OpenFadeMenu(){
		if (fadeCanvas != null) {
			fadeCanvas.TurnOn ();
		}
	}

	IEnumerator WaitToEndScene(){
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene (sceneName, LoadSceneMode.Single);		
	}
}
