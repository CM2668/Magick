using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript:MonoBehaviour {
	float q,e,r,f;
	//these three integers are for storing which spell key has been inputed
	int school, target, force;

    void Start() {
		school = 0;
		target = 0;
		force = 0;
	}

    void FixedUpdate() {
		//Debug.Log(q + " | " + e + " | " + r + " | " + f);
		q = Input.GetAxis("1st Spell Key");
		e = Input.GetAxis("2nd Spell Key");
		r = Input.GetAxis("3rd Spell Key");
		e = Input.GetAxis("4th Spell Key");

		/*if(school == 0 && target == 0 && force == 0) {
			if(q == 1)
				school = 1;
			else if(e == 1)
				school = 2;
			else if(r == 1)
				school = 3;
			else if(f == 1)
				school = 4;
		}
		else if(school != 0 && target == 0 && force == 0) {
			if(q == 1)
				target = 1;
			else if(e == 1)
				target = 2;
			else if(r == 1)
				target = 3;
			else if(f == 1)
				target = 4;
		}
		else if(school != 0 && target != 0 && force == 0) {
			if(q == 1)
				force = 1;
			else if(e == 1)
				force = 2;
			else if(r == 1)
				force = 3;
			else if(f == 1)
				force = 4;
		}*/

		if(Input.GetAxis("Launch Spell") == 1 && school != 0 && target != 0 && force != 0) {

		}

		//Debug.Log("click: " + Input.GetAxis("Launch Spell") + " | " + school + " | " + target + " | " + force);
	}
}
