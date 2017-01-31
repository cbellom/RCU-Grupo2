using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject panel;
    private bool loadScene = false;    
    private string sceneName;
    
    public void Load(string sceneName)
    {
        loadScene = true;
        panel.SetActive(true);
        this.sceneName = sceneName;
        StartCoroutine(LoadNewScene());
    }

    IEnumerator LoadNewScene(){
        yield return new WaitForSeconds(3);
        
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        while (!async.isDone)
        {
            loadScene = false;
            panel.SetActive(false);
            yield return null;
        }

    }

}