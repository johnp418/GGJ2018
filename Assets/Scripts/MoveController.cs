using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Maze
{
	public class MoveController : MonoBehaviour
	{
		public GameObject movePrefab;
		private Queue moves;

		// Use this for initialization
		void Start ()
		{
			moves = new Queue ();
		}

		public void RemoveAllMoves ()
		{
			for (int i = 0; i < transform.childCount; i++) {
				Destroy (transform.GetChild (i).gameObject);
			}
		}

		public int GetItemCount ()
		{
			return moves.Count;
		}

		public void AddMove (Vector3 move)
		{
			moves.Enqueue (move);
			AddToList (move);
		}

		public Vector3 RemoveMove ()
		{
			Vector3 removed = (Vector3)moves.Dequeue ();

			if (transform.childCount > 0) {
				Destroy (transform.GetChild (0).gameObject);
			}
			return removed;
		}

		private void AddToList (Vector3 move)
		{
			GameObject mo = (GameObject)GameObject.Instantiate (movePrefab);
			mo.transform.SetParent (transform);
			mo.SetActive (true);
			UserMove moveButton = mo.GetComponent<UserMove> ();
			moveButton.Setup (move, this);
		}
			
	}

}
