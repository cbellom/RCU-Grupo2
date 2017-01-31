using UnityEngine;
using System.Collections;

public class CinematicsController : MonoBehaviour {

	public Animator animator;
	public Camera camera;
    public GameObject[] particlesVapor;
    
    void Start () {
		animator = GetComponent<Animator> ();
		if (animator == null)
			Debug.LogError ("CinematicsController require an animator component");
		
		camera = GetComponentInChildren<Camera> ();
		if (camera == null)
			Debug.LogError ("Cinematics require an Child to type camera");
	}

	public void PlayCinematic ( int number) {
		animator.SetInteger ("number", number);
	}
	public void StopCinematic () {
		animator.SetInteger ("number", 0);
	}

    public void activeParticle()
    {
        foreach (GameObject item in particlesVapor) {
            item.SetActive(true);
        }
        
    }

    public void unEnableParticle()
    {
        foreach (GameObject item in particlesVapor)
        {
            item.SetActive(false);
        }
    }
}
