﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Maze
{
	public class ButtonController : MonoBehaviour
	{

		public GameController gameController;
		public Button resetBtn;
		public Button transmitBtn;
        public Button tryagainBtn;

        // Use this for initialization
        void Start ()
		{
			resetBtn.onClick.AddListener (ResetClick);
			transmitBtn.onClick.AddListener (TransmitClick);
            tryagainBtn.onClick.AddListener(TryAgainClick);
        }

		// Update is called once per frame
		void Update ()
		{

		}

		void TaskOnClick ()
		{
			Debug.Log ("You have clicked the button!");
		}

		private void ResetClick ()
		{
			gameController.ResetMoves ();
		}

		private void TransmitClick ()
		{
			gameController.Transmit ();

		}

        private void TryAgainClick ()
        {
            gameController.TryAgain ();
        }

	}

}
