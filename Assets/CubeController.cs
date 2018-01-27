using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter (Collider other)
	{
		print (other.tag);
		print (string.Format ("X {0} Y {1} Z {2}", other.transform.position.x, other.transform.position.y, other.transform.position.z));
		Destroy (other.gameObject);
	}

}
