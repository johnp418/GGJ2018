using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter (Collider col)
	{
		print (" On Trigger GOal ");
		if (col.gameObject.CompareTag ("Player")) {
			// Show win message 
			print (" You won !, loading next level");
			SceneManager.LoadScene ("Maze2");
		}
	}
}
