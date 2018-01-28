using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Maze
{
	public class GameController : MonoBehaviour
	{
		public Renderer cover;
		public Image memorizeImg;
		public Text timeText;
		private static int waitTime = 2;
		private float movespeed = 5;
		private bool isListeningEvent = false;
		private bool isDispatching = false;
		
		float timeAmt = (float)waitTime;
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


		void Awake ()
		{
			player = GameObject.FindGameObjectWithTag ("Player");
			GameObject moveList = GameObject.FindGameObjectWithTag ("MoveList");
			mc = moveList.GetComponent<MoveController> ();

		}
			
		// Use this for initialization
		void Start ()
		{
			time = timeAmt;
//			cover = GetComponent<MeshRenderer> ();
//			Renderer coverRenderer = cover.gameObject.GetComponent<Renderer> ();
//			coverRenderer.enabled = false;

			print ("Cover ?");
			print (cover);

//			cover.GetComponent<Renderer> ().enabled = false;

			// Hide cover when starting
			cover.enabled = false;

			StartCoroutine (waitForUserInput ());
		}


		IEnumerator waitForUserInput ()
		{
			// Let user remember the layout of the maze for "waitTime"
			yield return new WaitForSecondsRealtime (waitTime);

			// Cover the maze
			cover.enabled = true;	

			// Hide Countdown image and counter?
		

			// Starts listening to keyboard commands
			isListeningEvent = true;
		}
			

		// Update is called once per frame
		void Update ()
		{
			if (time > 0) {
				time -= Time.deltaTime;
				memorizeImg.fillAmount = time / timeAmt;
				timeText.text = time.ToString ("F");
			} else {
				memorizeImg.enabled = false;
				timeText.enabled = false;
			}
						
			if (isListeningEvent) {
				foreach (KeyCode keyToCheck in desiredKeys) {
					if (Input.GetKeyUp (keyToCheck)) {
						print (string.Format ("Key Clicked {0}", keyToCheck.ToString ()));
						Vector3 moveVector = keyDict [keyToCheck];
						mc.AddMove (moveVector);
					}				
				}
			}
				
			if (isDispatching && player) {
				if (target == null && mc.GetItemCount () > 0) {



					target = player.transform.position + mc.RemoveMove ();
					// Rotate player based on direction

				}
				if (target != null && target != player.transform.position) {
//					playC.anim.SetInteger ("Speed", 2);
					PlayerController a = player.GetComponent<PlayerController> ();


					player.transform.position = Vector3.MoveTowards (player.transform.position, (Vector3)target, movespeed * Time.deltaTime);
				} else {
					target = null;
				}

				// Game over condition
				if (mc.GetItemCount () == 0) {
					
				}
			}
		}
	}
}
