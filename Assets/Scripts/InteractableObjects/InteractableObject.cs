using UnityEngine;
using System;
using System.Collections;

public class InteractableObject : MonoBehaviour {

	public bool isAutoActivated = true;
	public float timeToTriggerAction = 0;
	protected GameObject player;

	public Action ObjectActivated
	{
		get;
		set;
	}

	public Action<GameObject> ObjectFinished
	{
		get;
		set;
	}

	void OnTriggerEnter(Collider other)
	{
		if (isAutoActivated && other.gameObject.CompareTag("Player"))
		{
			player = other.gameObject;
			ActiveObject();
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (!isAutoActivated && other.gameObject.CompareTag("Player"))
		{
			if(Input.GetKey(KeyCode.E))
			{
				player = other.gameObject;
				this.GetComponent<Collider> ().enabled = false;
				ActiveObject();
			}
		}
	}

	protected IEnumerator WaitFinishAction(float time)
	{
		yield return new WaitForSeconds(time);

		if (ObjectFinished != null)
			ObjectFinished(player);
	}

	private void ActiveObject()
	{
		if (ObjectActivated != null)
			ObjectActivated();		
	}
}
