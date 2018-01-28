using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Maze
{
	public class GameController : MonoBehaviour
	{
		public Renderer cover;
		public GameOverManager go;
		public Image memorizeImg;
		public Text timeText;
		public int waitTime = 5;
		private float movespeed = 5;
		private bool isListeningEvent = false;
		private bool isDispatching = false;
		
		float timeAmt;
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

			// Hide cover
			cover.enabled = false;	
		}

		public void ResetMoves ()
		{
			mc.RemoveAllMoves ();
		}

		public void TryAgain ()
		{
			SceneManager.LoadScene ("Maze1");
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
			time = (float)waitTime;

			// Hide cover when starting
			cover.enabled = false;

			StartCoroutine (waitForUserInput ());
		}


		IEnumerator waitForUserInput ()
		{
			// Let user remember the layout of the maze for "waitTime"
			yield return new WaitForSecondsRealtime (waitTime);

			// Starts listening to keyboard commands
			isListeningEvent = true;
		}
			

		// Update is called once per frame
		void Update ()
		{
			
			if (time > 0) {
				time -= Time.deltaTime;
				memorizeImg.fillAmount = time / (float)waitTime;
				timeText.text = time.ToString ("F");
			} else {
				memorizeImg.enabled = false;
				timeText.enabled = false;

				// Cover the maze
				cover.enabled = isDispatching ? false : true;
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
					player.transform.position = Vector3.MoveTowards (player.transform.position, (Vector3)target, movespeed * Time.deltaTime);
				} else {
					target = null;
				}

				// Game over condition
				if (mc.GetItemCount () == 0) {
					go.GameOver ();
				}
			}
		}
	}
}
