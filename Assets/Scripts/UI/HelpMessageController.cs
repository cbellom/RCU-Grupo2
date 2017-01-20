using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HelpMessageController : CanvasUI {
	
    [SerializeField]
    private float secondsDuration;
    [SerializeField]
    private Text helpLabel;

	void Start(){
		OnKeyPressed += HanldeOnKeyPressed;
	}

	public void ShowNewMessage(string message, float timeToShow) {
        helpLabel.text = message;
        StopAllCoroutines();
		StartCoroutine(ShowHelp(timeToShow));
    }

    private IEnumerator ShowHelp(float seconds)    {
        isTurnOn = true;

        yield return new WaitForSeconds(seconds);

        isTurnOn = false;
    }

	private void HanldeOnKeyPressed(){
		ShowNewMessage("TEST: Editor help message", secondsDuration);		
	}
    
}
