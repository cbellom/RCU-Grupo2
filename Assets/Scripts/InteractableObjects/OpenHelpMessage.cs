using UnityEngine;
using System.Collections;

public class OpenHelpMessage : InteractableObject {
	public float timeToShow = 5f;
	public string message;
	private HelpMessageController helpMessage;

	void Awake() {
        helpMessage = GameObject.FindObjectOfType<HelpMessageController>();
        if (helpMessage == null)
            Debug.LogError("OpenHelpMessage requires a GameObject in scene of type HelpMessageController");

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
		if (helpMessage != null)
			helpMessage.ShowNewMessage (message, timeToShow);
	}

}
