using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class SceneCamerasController {

	public static void ActiveCameraByName(string cameraName){
		Camera[] cameras = GameObject.FindObjectsOfType<Camera>();
		foreach (Camera cam in cameras) {
			if (cam.name == cameraName)
				cam.enabled = true;
			else
				cam.enabled = false;
		}
	}


}
