using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{

	void OnTriggerEnter (Collider col)
	{
		print (" On Trigger GOal ");
		if (col.gameObject.CompareTag ("Player")) {
			// Show win message 
//			SceneManager.LoadScene ("Maze2");

			Application.Quit ();
		}
	}
}
