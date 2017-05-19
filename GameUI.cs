using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameUI : MonoBehaviour 
{
	[SerializeField]GameObject gameUI;
	[SerializeField]GameObject mainMenu;
	[SerializeField]GameObject playerPrefab;
	[SerializeField]GameObject playerStartPosition;


	void Start()
	{
		ShowMainMenu ();
	}

	void OnEnable()
	{
		EventManager.onStartGame += ShowGameUI;
		EventManager.onPlayerDeath += ShowMainMenu;
	}
	void OnDisable()
	{
		EventManager.onStartGame -= ShowGameUI;
		EventManager.onPlayerDeath -= ShowMainMenu;
	}

	void ShowMainMenu()
	{
		mainMenu.SetActive (true);
		gameUI.SetActive (false);

	}

	void ShowGameUI()
	{
		mainMenu.SetActive (false);
		gameUI.SetActive (true);
		Instantiate (playerPrefab, playerStartPosition.transform.position, playerStartPosition.transform.rotation);
	}
		
}

