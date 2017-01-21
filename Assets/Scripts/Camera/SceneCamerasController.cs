using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneCamerasController : MonoBehaviour {

	public List<Camera> cameras = new List<Camera> ();

	void Start () {
	}

	public void ActiveCameraByName(string cameraName){
		foreach (Camera cam in cameras) {
			if (cam.name == cameraName)
				cam.enabled = true;
			else
				cam.enabled = false;
		}
	}

}
