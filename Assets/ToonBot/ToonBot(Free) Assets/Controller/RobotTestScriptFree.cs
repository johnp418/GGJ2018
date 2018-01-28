using UnityEngine;
using System.Collections;

public class RobotTestScriptFree : MonoBehaviour {

	private Animator anim;
	private float jumpTimer = 0;

	void Start () {
	
		anim = this.gameObject.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		//Controls the Input for running animations
		// 1: walk
		//2: Run
		//3: Jump
			
		if(Input.GetKey("r")) anim.SetInteger("Speed", 2);
			else if(Input.GetKey("w")) anim.SetInteger("Speed", 1);
				else anim.SetInteger("Speed", 0);

		if (Input.GetKey ("j")) {

			jumpTimer = 1;
			anim.SetBool ("Jumping", true);

			}

		if (jumpTimer > 0.5) jumpTimer -= Time.deltaTime;
			else if (anim.GetBool ("Jumping") == true) anim.SetBool ("Jumping", false);

	}
}
