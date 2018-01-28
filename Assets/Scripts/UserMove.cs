using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Maze
{
	public class UserMove : MonoBehaviour
	{

		public Image moveImage;
		public Text moveText;

		// Use this for initialization
		void Start ()
		{

		}

		public void Setup (Vector3 vec, MoveController panel)
		{
			if (vec == Vector3.left) {
				moveText.text = "Left";
			} else if (vec == Vector3.right) {
				moveText.text = "Right";
			} else if (vec == Vector3.forward) {
				moveText.text = "Up";
			} else {
				moveText.text = "Down";
			}
		}
	}

}
