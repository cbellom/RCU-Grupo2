using UnityEngine;
using System;
using System.Collections;

[RequireComponent (typeof (CanvasGroup))]
public class CanvasUI : MonoBehaviour {
	
	[SerializeField]
	protected float fadeSpeed;
	[SerializeField]
	protected bool isTurnOn = false;
	[SerializeField]
	private KeyCode keyToOpenCanvas;
	private CanvasGroup canvasGroup;

	public Action OnKeyPressed
	{
		get;
		set;
	}

	public Action OnFrameUpdated
	{
		get;
		set;
	}

	private void Awake() {
		canvasGroup = GetComponent<CanvasGroup>();
		canvasGroup.alpha = 0;
	}

	private void Update()
	{
		if (isTurnOn && canvasGroup.alpha < 1)
			canvasGroup.alpha += Time.deltaTime * fadeSpeed;
		else if (!isTurnOn && canvasGroup.alpha > 0)
			canvasGroup.alpha -= Time.deltaTime * fadeSpeed;


		#if UNITY_EDITOR
		if (Input.GetKey(keyToOpenCanvas) ) {
            if (OnKeyPressed != null) OnKeyPressed();
            else isTurnOn = !isTurnOn;
        }
		#endif

		if (OnFrameUpdated != null)
			OnFrameUpdated ();
	}

	public void TurnOn(){
		isTurnOn = true;
	}

}
