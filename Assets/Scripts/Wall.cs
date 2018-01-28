using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Maze
{
	public class Wall : MonoBehaviour
	{
		public GameOverManager go;

		void OnTriggerEnter (Collider col)
		{
			if (col.gameObject.CompareTag ("Player")) {
				go.GameOver ();
				Destroy (col.gameObject);
			}
		}
	}
}

