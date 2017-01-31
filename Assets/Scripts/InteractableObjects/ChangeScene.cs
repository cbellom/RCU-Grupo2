using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : InteractableObject {

	public string sceneName;
	public CanvasUI fadeCanvas;
    public SceneLoader sceneLoader;

    void Awake() {
		ObjectActivated += HandleObjectActived;
		ObjectFinished += HandleObjectExpired;
	}

	private void HandleObjectActived() {
		OpenFadeMenu ();
		StopAllCoroutines ();
		StartCoroutine(WaitFinishAction(timeToTriggerAction));
	}

	private void HandleObjectExpired(GameObject player)
    {
        sceneLoader.Load(sceneName);
    }

	private void OpenFadeMenu(){
		if (fadeCanvas != null) {
			fadeCanvas.TurnOn ();
		}
	}
}
