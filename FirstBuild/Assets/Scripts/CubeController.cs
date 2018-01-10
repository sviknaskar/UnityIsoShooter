using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class CubeController : MonoBehaviour {
	public float speed = 0.5f;
	public float angularSpeed = 5f;
	Rigidbody rb;
	public VirtualJoystick stick;
	Vector3 lastRotation;
	void Start () {
		rb = GetComponent<Rigidbody> ();
		lastRotation = new Vector3 (-90, 0, 0);
	}
	void FixedUpdate () {
		if (CrossPlatformInputManager.GetButton ("Jump"))
			transform.position = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.MoveRotation (Quaternion.Euler (-90, stick.Angle (), 0));
		if (stick.Value () > 0 && rb.velocity.magnitude<5.0f)
			rb.AddForce (-transform.up * stick.Value ());
	}
}
