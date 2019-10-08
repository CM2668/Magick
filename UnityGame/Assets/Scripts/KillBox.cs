using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class KillBox : MonoBehaviour
{
	void OnTriggerEnter(Collider obj)
	{
		if(obj.tag == "Player")
		{
			SceneManager.LoadScene("MainScene");
		}
	}
}
