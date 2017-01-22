using UnityEngine;
using System.Collections;

public class Rotador : MonoBehaviour {

    public float speed = 10;
	void Update () {

        transform.Rotate(new Vector3(0, speed,0)* Time.deltaTime);
      
    }
}
