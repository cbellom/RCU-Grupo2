using UnityEngine;
using System.Collections;

public class ExampleObjectTrap : InteractableObject {

	void Awake() {
		ObjectActivated += HandleExampleObjectActived;
		ObjectFinished += HandleExampleObjectExpired;
	}

	private void HandleExampleObjectActived() {
		SomethigHappensOnActivate ();
		StopAllCoroutines ();
		StartCoroutine(WaitFinishAction(timeToTriggerAction));
	}

	private void HandleExampleObjectExpired(GameObject player) {
		SomethigHappensOnOver ();
		Destroy(gameObject);
	}

	private void SomethigHappensOnActivate() {
		Debug.Log ("You active this trap!! The limit is your imagination");
	}

	private void SomethigHappensOnOver() {
		Debug.Log ("Trap is Over!! The limit is your imagination");
	}
}
