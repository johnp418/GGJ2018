﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Maze
{
	public class GameController : MonoBehaviour
	{
		public Image memorizeImg;
		public Text timeText;
		private int waitTime = 2;
		private float movespeed = 5;
		private bool isListeningEvent = false;
		private bool isDispatching = false;

		float timeAmt = 2;
	 	float time;

		MoveController mc;
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

		public void Transmit ()
		{
			print (string.Format (" Number of moves = {0}", mc.GetItemCount ()));

			isListeningEvent = false;
			isDispatching = true;
		}

		public void ResetMoves ()
		{
			mc.RemoveAllMoves ();
		}

        public void TryAgain()
        {
            SceneManager.LoadScene("Maze MJ");
        }

		void Awake ()
		{
			player = GameObject.FindGameObjectWithTag ("Player");
			GameObject moveList = GameObject.FindGameObjectWithTag ("MoveList");
			mc = moveList.GetComponent<MoveController> ();
			print ("MC");
			print (mc);
		}
			
		// Use this for initialization
		void Start ()
		{
			time = timeAmt;
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

			print (string.Format (" Number of moves = {0}", mc.GetItemCount ()));

			isListeningEvent = false;
			isDispatching = true;


			// Removes all moves in the queue
			mc.RemoveAllMoves ();


		}
			

		// Update is called once per frame
		void Update ()
		{
			if (time > 0) {
					 time -= Time.deltaTime;
					 memorizeImg.fillAmount = time / timeAmt;
					 timeText.text = time.ToString("F");
					 print("I was called");
			} else
      {
          memorizeImg.enabled = false;
          timeText.enabled = false;
      }
						
			if (isListeningEvent) {
				foreach (KeyCode keyToCheck in desiredKeys) {
					if (Input.GetKeyUp (keyToCheck)) {
						print (string.Format ("Key Clicked {0}", keyToCheck.ToString ()));
						Vector3 moveVector = keyDict [keyToCheck];
//						moves.Enqueue (moveVector);
						mc.AddMove (moveVector);
					}				
				}
			}
				
			if (isDispatching && player) {
				if (target == null && mc.GetItemCount () > 0) {
					target = player.transform.position + mc.RemoveMove ();
				}
				if (target != null && target != player.transform.position) {
//					playC.anim.SetInteger ("Speed", 2);
					PlayerController a = player.GetComponent<PlayerController> ();
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
		}
	}

}
