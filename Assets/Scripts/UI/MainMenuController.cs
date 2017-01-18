using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    [SerializeField]
    private float fadeSpeed;
    [SerializeField]
    private bool isTurnOn = false;
    private CanvasGroup canvasGroup;

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
        if (Input.GetKey(KeyCode.M))
            isTurnOn = true;
#endif
    }

    public void ChangeScene(string sceneName) {
        Debug.Log("Load scene " + sceneName);
		StartCoroutine(LoadOtherScene(sceneName, fadeSpeed));
    }

	private IEnumerator LoadOtherScene(string sceneName, float seconds)    {
		isTurnOn = false;

		yield return new WaitForSeconds(seconds);
		isTurnOn = true;
		SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
	}
}
