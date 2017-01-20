using UnityEngine;
using System.Collections;

public class RotateLigth : MonoBehaviour {
	public float rotationSpeed;
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0,rotationSpeed * Time.deltaTime, 0));
	}
}
