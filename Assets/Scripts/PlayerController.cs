using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
	public class PlayerController : MonoBehaviour
	{
		public float speed;
		//		public Transform playerTransform;
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

		//		void OnCollisionEnter (Collision col)
		//		{
		//
		//			transform.position = col.transform.position;
		//
		//		}

		//		void Update ()
		//		{
		//			Move ();
		//		}

		void Move ()
		{
			// Set the movement vector based on the axis input.
			if (Input.GetKeyUp (KeyCode.LeftArrow)) {
//				transform.Translate (Vector3.right);
//				rb.MovePosition (Vector3.right);
				movement = Vector3.right;

			}
			if (Input.GetKeyUp (KeyCode.RightArrow)) {
//				transform.Translate (Vector3.left);
				movement = Vector3.left;
			}
			if (Input.GetKeyUp (KeyCode.DownArrow)) {
				transform.Translate (Vector3.forward);
//				rb.MovePosition (Vector3.forward);
				movement = Vector3.forward;
			}
			if (Input.GetKeyUp (KeyCode.UpArrow)) {
//				transform.Translate (Vector3.back);
				movement = Vector3.back;
			}
			// Normalise the movement vector and make it proportional to the speed per second.
//			movement = movement.normalized * speed * Time.deltaTime;

			// Move the player to it's current position plus the movement.
			rb.MovePosition (transform.position + movement);
		}

		private Vector3 velocity = Vector3.zero;
		public float smoothTime = 0.3f;

		void Update ()
		{
//			 Current pos


			if (Input.GetKeyUp (KeyCode.LeftArrow)) {
				transform.Translate (Vector3.right);
				//				rb.MovePosition (Vector3.right);
			}
			if (Input.GetKeyUp (KeyCode.RightArrow)) {
				transform.Translate (Vector3.left);
			}
			if (Input.GetKeyUp (KeyCode.DownArrow)) {
//				transform.Translate (Vector3.forward);
				//				rb.MovePosition (Vector3.forward);
//				Vector3 currPos = transform.position;
//				Vector3 targetPos = currPos + Vector3.forward;
				transform.position += Vector3.forward * Time.deltaTime;
//				transform.position = Vector3.SmoothDamp (currPos, targetPos, ref velocity, smoothTime * Time.deltaTime);
			}
			if (Input.GetKeyUp (KeyCode.UpArrow)) {
				transform.Translate (Vector3.back);
			}
		}
	}

}
