using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
	public class GameController : MonoBehaviour
	{
		private int waitTime = 10;
		private float movespeed = 5;
		private Queue moves = null;
		private bool isListeningEvent = false;
		private bool isDispatching = false;

		GameObject player;
		Vector3? target;

		private KeyCode[] desiredKeys = 
			{ KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow };

		private Dictionary<KeyCode, Vector3> keyDict = new Dictionary<KeyCode, Vector3> () {
			{ KeyCode.LeftArrow, Vector3.left },
			{ KeyCode.RightArrow, Vector3.right },
			{ KeyCode.DownArrow, Vector3.back },
			{ KeyCode.UpArrow, Vector3.forward }
		};


		void Awake ()
		{
			player = GameObject.FindGameObjectWithTag ("Player");
//			GameObject arrowUIButton = (GameObject)GameObject.Instantiate (buttonPrefab);
//			arrowUIButton;
		}
			
		// Use this for initialization
		void Start ()
		{

			StartCoroutine (waitForUserInput ());
			print ("Started coroutine");
		}


		IEnumerator waitForUserInput ()
		{
			// Let user remember the layout of the maze for "waitTime"
			yield return new WaitForSecondsRealtime (waitTime);

			// Cover the maze while user presses arrow keys 


			// Code below runs after "waitTime"

			StartRecording ();


			yield return new WaitForSecondsRealtime (5);

			print (string.Format (" Number of moves = {0}", moves.Count));

			isListeningEvent = false;
			isDispatching = true;


			print (" Hello Start ");



		}
			

		// Update is called once per frame
		void Update ()
		{
			if (isListeningEvent) {
				foreach (KeyCode keyToCheck in desiredKeys) {
					if (Input.GetKeyUp (keyToCheck)) {
						print (string.Format ("Key Clicked {0}", keyToCheck.ToString ()));
						Vector3 moveVector = keyDict [keyToCheck];
						moves.Enqueue (moveVector);
					}				
				}
			}
				
			if (isDispatching && player) {
				if (target == null && moves.Count > 0) {
					target = player.transform.position + (Vector3)moves.Dequeue ();
				}
				if (target != null && target != player.transform.position) {
					player.transform.position = Vector3.MoveTowards (player.transform.position, (Vector3)target, movespeed * Time.deltaTime);
				} else {
					target = null;
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
