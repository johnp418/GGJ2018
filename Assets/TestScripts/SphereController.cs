using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{

	public float speed;
	private Rigidbody rb;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		speed = 1.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			transform.Translate (Vector3.right);
			//				rb.MovePosition (Vector3.right);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			transform.Translate (Vector3.left);
		}
		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			transform.Translate (Vector3.forward);
			//				rb.MovePosition (Vector3.forward);
			//				Vector3 currPos = transform.position;
			//				Vector3 targetPos = currPos + Vector3.forward;
//			transform.position += Vector3.forward * Time.deltaTime;
			//				transform.position = Vector3.SmoothDamp (currPos, targetPos, ref velocity, smoothTime * Time.deltaTime);
		}
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			transform.Translate (Vector3.back);
		}
	}

	void FixedUpdate ()
	{
//		float ho = Input.GetAxis ("Horizontal");
//		float ve = Input.GetAxis ("Vertical");
//		Vector3 mv = new Vector3 (ho, 0.0f, ve);
//		rb.AddForce (mv * speed);
	}
}
