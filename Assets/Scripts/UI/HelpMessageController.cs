using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (CanvasGroup))]
public class HelpMessageController : MonoBehaviour {

    [SerializeField]
    private float fadeSpeed;
    [SerializeField]
    private float secondsDuration;
    [SerializeField]
    private Text helpLabel;
    [SerializeField]
    private bool isTurnOn = false;
    private CanvasGroup canvasGroup;

    private void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    private void Update() {
        if (isTurnOn && canvasGroup.alpha < 1)
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
        else if (!isTurnOn && canvasGroup.alpha > 0)
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;

#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.H))
            ShowNewMessage("TEST: Editor help message");
#endif
    }

    public void ShowNewMessage(string message) {
        helpLabel.text = message;
        StopAllCoroutines();
        StartCoroutine(ShowHelp(secondsDuration));
    }

    private IEnumerator ShowHelp(float seconds)    {
        isTurnOn = true;

        yield return new WaitForSeconds(seconds);

        isTurnOn = false;
    }
    
}
