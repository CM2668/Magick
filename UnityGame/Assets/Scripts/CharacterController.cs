using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
	float turn, velX, velZ, jump, sprintMod, health = 20;
	Rigidbody move;
	Ray ray;
	public GameObject weapon;

	void Start () {
		move = GetComponent<Rigidbody>();
	}

	void Update () {
		turn = Input.GetAxis("Mouse X");
		velZ = Input.GetAxis("Horizontal");
		velX = -Input.GetAxis("Vertical");
		jump = Input.GetAxis("Jump");
		if(Input.GetKey(KeyCode.LeftShift))
			sprintMod = 10.0f;
		else
			sprintMod = 5.0f;

	}
	
	void FixedUpdate () {
		if(Physics.Raycast(transform.position, Vector3.down, 1.0f)) {
			//Debug.Log("Able to jump");
			move.velocity = new Vector3(move.velocity.x, jump*5, move.velocity.z);
		}
		else {
			//Debug.Log("Not able to jump");
		}
		//Debug.Log(velX + " | " + jump + " | " + velZ);
		transform.position += transform.forward*Time.deltaTime*velZ*sprintMod;
		transform.position += transform.right*Time.deltaTime*velX*sprintMod;
		transform.rotation = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y + turn*5, 0.0f);

		//cast magicks
		if(Input.GetKeyDown(KeyCode.Mouse0)) {
			Debug.Log("attacking");
			weapon.GetComponent<Animation>().Play("Sword Swing");
		}

		//player death
		if(health <= 0) {
			Destroy(gameObject);
		}
	}
}