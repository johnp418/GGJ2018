using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
	public class GameController : MonoBehaviour
	{

		private bool isListeningEvent = false;
		private bool isDispatching = false;
		private Queue moves = null;
		private KeyCode[] desiredKeys = 
			{ KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow };

		private Vector3 velocity = Vector3.zero;
		public float smoothTime = 0.3F;


		private Dictionary<KeyCode, Vector3> keyDict = new Dictionary<KeyCode, Vector3> () {
			{ KeyCode.LeftArrow, Vector3.left },
			{ KeyCode.RightArrow, Vector3.right },
			{ KeyCode.DownArrow, Vector3.back },
			{ KeyCode.UpArrow, Vector3.forward }
		};


		GameObject player;

		void Awake ()
		{
			Debug.Log ("Hello");
		}
			
		// Use this for initialization
		void Start ()
		{

			StartCoroutine (Example ());
			print ("Started coroutine");
			StartRecording ();
		}


		IEnumerator Example ()
		{
//			print (Time.time);
			yield return new WaitForSecondsRealtime (10);
//			print (Time.time);

			isListeningEvent = false;

			print (string.Format (" Queue count = {0}", 
				moves.Count));

			player = GameObject.FindGameObjectWithTag ("Player");

			isDispatching = true;
//			foreach (KeyCode k in moves) {
//				print (string.Format ("Key in Queue {0}", k.ToString ()));
//
//				if (k == KeyCode.LeftArrow) {
//					player.transform.Translate (Vector3.right);
//				}
//
//				if (k == KeyCode.RightArrow) {
//					player.transform.Translate (Vector3.left);
//				}
//				if (k == KeyCode.DownArrow) {
//					player.transform.Translate (Vector3.forward);
//				}
//				if (k == KeyCode.UpArrow) {
//					player.transform.Translate (Vector3.back);
//				}
//			}
		}

		// Update is called once per frame
		void Update ()
		{
//			print (string.Format ("isListening {0}", isListeningEvent));

			if (isListeningEvent) {
				foreach (KeyCode keyToCheck in desiredKeys) {
					if (Input.GetKeyUp (keyToCheck)) {
						print (string.Format ("Key Clicked {0}", keyToCheck.ToString ()));
						Vector3 moveVector = keyDict [keyToCheck];
						moves.Enqueue (moveVector);
					}				
				}
			}

			if (isDispatching) {
				while (moves.Count > 0) {
					Vector3 move = (Vector3)moves.Dequeue ();

					player.transform.Translate (move);

					// Current pos
//					Vector3 currPos = player.transform.position;
//					Vector3 targetPos = currPos + move;
//					player.transform.position = targetPos;
				}
			}
		}

		void StartRecording ()
		{
			print ("Start Recording event");
			isListeningEvent = true;
			moves = new Queue ();

		}
	}

}
