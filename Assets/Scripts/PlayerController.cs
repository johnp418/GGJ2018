using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
	public class PlayerController : MonoBehaviour
	{
		public float speed;
		private Rigidbody rb;

		Vector3 movement;

		void Start ()
		{
			rb = GetComponent<Rigidbody> ();
//			playerTransform = transform;
		}

		void FixedUpdate ()
		{
		}


		void Update ()
		{
//			if (Input.GetKeyUp (KeyCode.LeftArrow)) {
//				transform.Translate (Vector3.left);
//				//				rb.MovePosition (Vector3.right);
//			}
//			if (Input.GetKeyUp (KeyCode.RightArrow)) {
//				transform.Translate (Vector3.right);
//			}
//			if (Input.GetKeyUp (KeyCode.DownArrow)) {
//				transform.Translate (Vector3.back);
//				//				rb.MovePosition (Vector3.forward);
////				Vector3 currPos = transform.position;
////				Vector3 targetPos = currPos + Vector3.forward;
////				transform.position += Vector3.forward * Time.deltaTime;
////				transform.position = Vector3.SmoothDamp (currPos, targetPos, ref velocity, smoothTime * Time.deltaTime);
//			}
//			if (Input.GetKeyUp (KeyCode.UpArrow)) {
//				transform.Translate (Vector3.forward);
//			}
		}
	}

}
