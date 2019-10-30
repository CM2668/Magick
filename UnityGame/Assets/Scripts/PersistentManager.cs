using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersistentManager : MonoBehaviour
{
	public static PersistentManager instance {get; private set;}
	public Button resetButton;
	public GameObject player;
	public string zone;

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
		
		player = GameObject.FindGameObjectWithTag("Player");
		zone = "Town";
	}

	void Update()
	{
		if (player != null)
		{
			if (zone != "Town" && player.transform.position.x <= 10f && player.transform.position.z <= 5f)
				zone = "Town";
			else if (zone != "Forest" && player.transform.position.x <= 10f && player.transform.position.z >= 5f)
				zone = "Forest";
		}
	}

	void FixedUpdate()
	{

	}

	public void resetWorld()
	{
		Debug.Log("Resetting World");	
		SceneManager.LoadScene("MainScene");

		if(player == null)
			player = GameObject.FindGameObjectWithTag("Player");
	}

	public void SetZone(string z) {zone = z;}
	public void SetPlayer(GameObject p) {player = p;}
	public string GetZone() {return zone;}
}