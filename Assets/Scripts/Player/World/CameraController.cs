using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public float heightOffset = 5;
	public float speedMod = 10.0f;
	public Transform target;
	public Vector3 offset;
	private Vector3 cameraPosition;

	void Start () {
		cameraPosition = Vector3.zero;
		transform.LookAt(target);
	}

	void Update () {
		cameraPosition.x = target.position.x * offset.x; 
		cameraPosition.y = target.position.y + offset.y; 
		cameraPosition.z = target.position.z * offset.z; 
		transform.position = cameraPosition;
		transform.LookAt (target);
	}
}