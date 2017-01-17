using UnityEngine;

public class CamBehaviour : MonoBehaviour {

	public Transform character;
	public float min_distance;
	public float height;

	void Start() {
		min_distance = 2;
	}
	void Update () {
		Vector3 target_pos = character.position * 2;
		if (target_pos.magnitude < min_distance)
			target_pos = target_pos.normalized * min_distance;
		target_pos.y = target_pos.y + height;
		transform.position = transform.position + (target_pos - transform.position) / 10;
		transform.LookAt(character);

	}
}
