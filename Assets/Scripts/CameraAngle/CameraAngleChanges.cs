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

//	void Start() {
//		currentView = views[0];
//		currentView = views[1];
//		currentView = views[2];
//		currentView = views[3];
//		currentView = views[4];
//		currentView = views[5];
//		currentView = views[6];
//		currentView = views[7];
//	}
	IEnumerator Start()
	{
		currentView = views[0];
		yield return new WaitForSeconds(0.5f);
		currentView = views[1];
	}

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

