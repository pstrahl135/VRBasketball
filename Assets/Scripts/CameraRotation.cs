using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float  rotationSpeed = 5.0f, mouseX = Input.GetAxis ("Mouse X") * rotationSpeed, mouseY = Input.GetAxis ("Mouse Y") * rotationSpeed;
		transform.localRotation *= Quaternion.Euler (-mouseY, mouseX, 0);
		Camera camera = GetComponentInChildren<Camera> ();
		camera.transform.localRotation *= Quaternion.Euler (-mouseY, 0, 0);
	}
}
