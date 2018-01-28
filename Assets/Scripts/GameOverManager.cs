using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Maze
{
	public class GameOverManager : MonoBehaviour
	{

		public Text gameOver;

		// Use this for initialization
		void Awake ()
		{
			print (gameOver);
			gameOver.enabled = false;
		}

		public void GameOver ()
		{
			gameOver.enabled = true;
		}
	}

}
