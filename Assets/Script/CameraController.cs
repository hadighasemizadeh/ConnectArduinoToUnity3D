using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform target;
	public Vector3 offset = new Vector3 (0,.6F,-2.6F);
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * 100);
//		transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * 100);
	}
}
