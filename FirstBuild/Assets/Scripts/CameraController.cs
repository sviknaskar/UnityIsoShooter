using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	
	public GameObject player;
	public int camPositionOffset = 10;
	public int camHeight = 15;
	public float followSpeed=0.01f;
	int camPos=2;
	int i=0;
	public List<GameObject> positionObj;
	List <Vector3>positions;

	void Start()
	{
		positions = new List<Vector3> (4);
		//Debug.Log (player.transform.position + (Vector3.forward * camPositionOffset) + Vector3.up * camHeight);
		GetCameraPosition();
		transform.position = positions[0];
	}

	void GetCameraPosition(){
		for (int i = 0; i < 4; i++)
			positions.Add (positionObj[i].transform.position);
	}
	/*
	void GetCameraPosition(){
		positions.Add (player.transform.position + (Vector3.forward * camPositionOffset) + Vector3.up * camHeight);
		positions.Add (player.transform.position + (Vector3.left * camPositionOffset) + Vector3.up * camHeight);
		positions.Add (player.transform.position + (Vector3.forward * -camPositionOffset) + Vector3.up * camHeight);
		positions.Add (player.transform.position + (Vector3.left * -camPositionOffset) + Vector3.up * camHeight);
	}*/

	void FixedUpdate()
	{
		/*
		if (Vector3.Magnitude (transform.position - positions [i + 1]) < 1) {
			if (i < 2)
				i++;
			else
				i = -1;
		}
		*/
		if (Input.GetKey (KeyCode.C)) {
			if (i < positions.Count-2)
				i++;
			else
				i = -1;
		}
		transform.position = Vector3.Lerp (transform.position, positions[i+1], Time.deltaTime * 1.0f);
		transform.LookAt (player.transform.position);
	}
}
