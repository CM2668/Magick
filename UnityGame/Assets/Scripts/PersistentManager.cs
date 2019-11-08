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
	public GameObject taskComplete;
	public Text taskDesc;
	double timer;

	#region Task Flags
	public bool enteredForest = false;
	public bool enteredCave = false;
	public bool enteredCastle = false;
	public bool fullyExplored = false;
	public bool SamMurdered = false;
	#endregion

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
			else if (zone != "Forest" && player.transform.position.x <= 10f && player.transform.position.z > 5f)
				zone = "Forest";
			else if (zone != "Castle" && player.transform.position.x > 10f && player.transform.position.z >= -5f)
				zone = "Castle";
			else if (zone != "Cave" && player.transform.position.x > 10f && player.transform.position.z < -5f)
				zone = "Cave";
		}

		#region Task System
		if (!fullyExplored)
		{
			if (!enteredForest && zone == "Forest")
			{
				enteredForest = true;
				TaskComplete(true, "Forest discovered");
			}
			else if (!enteredCastle && zone == "Castle")
			{
			enteredCastle = true;
				TaskComplete(true, "Castle discovered");
			}
			else if (!enteredCave && zone == "Cave")
			{
				enteredCave = true;
				TaskComplete(true, "Cave discovered");
			}

			if (enteredForest && enteredCastle && enteredCave)
			{
				fullyExplored = true;
				TaskComplete(true, "All locations discovered");
			}
		}
		#endregion

		if (timer > 0)
			timer -= Time.deltaTime;
		else if (timer <= 0)
			TaskComplete(false, "");
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

	public void TaskComplete(bool active, string desc)
	{
		taskComplete.SetActive(active);
		taskDesc.text = desc;
		timer = 5;
	}

	#region set variables
	public void SetZone(string z) { zone = z; }
	public void SetPlayer(GameObject p) { player = p; }
	public void SetSamMurder(bool b) { SamMurdered = b; }
	#endregion
	#region get variables
	public string GetZone() { return zone; }
	#endregion
}