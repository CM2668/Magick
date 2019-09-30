using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersistentManager : MonoBehaviour {
	public static PersistentManager instance {get; private set;}
	public Button resetButton;
	public GameObject player;
	public string gameState;

	private void Awake() {
		if(instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else {
			Destroy(gameObject);
		}
		
		player = GameObject.FindGameObjectWithTag("Player");
		gameState = "Main Menu";
	}

	void Update() {

	}

	void FixedUpdate() {

	}

	public void startGame() {
		SceneManager.LoadScene("Realm 1");
		gameState = "Playing";
	}

	public void resetWorld() {
		Debug.Log("Resetting World");	
		SceneManager.LoadScene("Realm 1");

		if(player == null)
			player = GameObject.FindGameObjectWithTag("Player");
		gameState = "Playing";
	}

	public void setPlayer(GameObject p) {player = p;}
	public void setReset(Button b) {resetButton = b;}
	public void setGameState(string g) {gameState = g;}
}