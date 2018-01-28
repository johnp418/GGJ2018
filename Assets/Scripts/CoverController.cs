using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverController : MonoBehaviour {
	public float sec = 10;
	public Renderer rend;

	void Start()
	{
		rend = GetComponent<Renderer> ();
		rend.enabled = false;
		StartCoroutine (LateCall ());
	}

	IEnumerator LateCall()
	{
		
		yield return new WaitForSecondsRealtime (sec);
		print ("Covered for memorization.");
		rend.enabled = true;	
		yield return new WaitForSecondsRealtime (5);

		rend.enabled = false;	
		print ("Uncovered."); 
	
	}


}
