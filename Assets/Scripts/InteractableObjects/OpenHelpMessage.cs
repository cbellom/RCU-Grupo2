using UnityEngine;
using System.Collections;

public class OpenHelpMessage : InteractableObject {
	public string message;
	public HelpMessageController helpMessage;

	void Awake() {
		ObjectActivated += HandleExampleObjectActived;
		ObjectFinished += HandleExampleObjectExpired;
	}

	private void HandleExampleObjectActived() {
		OpenMessage ();
		StopAllCoroutines ();
		StartCoroutine(WaitFinishAction(timeToTriggerAction));
	}

	private void HandleExampleObjectExpired(GameObject player) {
		Destroy(gameObject);
	}

	private void OpenMessage() {
		Debug.Log ("Open Help");
		if (helpMessage != null) {
			helpMessage.ShowNewMessage (message);
		}
	}

}
