using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Wall : MonoBehaviour
{
    public Text gameoverText;
    private bool status = true;

	// Use this for initialization
	void Start ()
	{
        gameoverText.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			Destroy (col.gameObject);
			status = false;
		}
	}

	void OnGUI() {
		if (status == false) {
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "Better luck next time!");
          gameoverText.enabled = true;
        }

    }

}
