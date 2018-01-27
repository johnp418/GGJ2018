using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAngleChanges : MonoBehaviour {
	public Transform[] views;
	public float transitionSpeed;
	Transform currentView;

	//	public Camera mainCam;
	//	void Start() {
	//		mainCam.transform.position = new Vector3 (0.31f, 5.28f, -15.7f);
	//		mainCam.transform.eulerAngles = new Vector3 (20f, 0f, 0f);
	//	}

	void Start() {

	}

	void Update() {
		if (Input.GetKey (KeyCode.Alpha2)) {
			currentView = views[1];
		}	
		if (Input.GetKey (KeyCode.Alpha1)) {
			currentView = views[0];
		}
	}
	//
	void LateUpdate() {
		if (currentView != null) {
			transform.position = Vector3.Lerp (transform.position, currentView.position, Time.deltaTime * transitionSpeed);
			Vector3 currentAngle = new Vector3 (
				Mathf.LerpAngle (transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
				Mathf.LerpAngle (transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
				Mathf.LerpAngle (transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));
			transform.eulerAngles = currentAngle;
		}

	}

}

