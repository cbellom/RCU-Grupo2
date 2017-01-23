using UnityEngine;
using System.Collections;

public class OpenHelpMessage : InteractableObject {
    public bool mustDestroyObject = true;
	public float timeToShow = 5f;
	public string message;
	private HelpMessageController helpMessage;

	void Awake() {
        helpMessage = GameObject.FindObjectOfType<HelpMessageController>();
        if (helpMessage == null)
            Debug.LogError("OpenHelpMessage requires a GameObject in scene of type HelpMessageController");

        ObjectActivated += HandleObjectActived;
		ObjectFinished += HandleObjectExpired;
	}

	private void HandleObjectActived() {
		OpenMessage ();
		StopAllCoroutines ();
		StartCoroutine(WaitFinishAction(timeToTriggerAction));
	}

	private void HandleObjectExpired(GameObject player) {
		if(mustDestroyObject)
            Destroy(gameObject);
	}

	private void OpenMessage() {
		if (helpMessage != null)
			helpMessage.ShowNewMessage (message, timeToShow);
	}

}
