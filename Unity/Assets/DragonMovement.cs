using UnityEngine;
using System.Collections;

public class DragonMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody.AddRelativeTorque (Vector3.down * 7);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody.AddRelativeForce (new Vector3(0f, 0f, 1f) * 400);
	}
}
