using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour 
{

	public delegate void StartGameDelegate();
	public static StartGameDelegate onStartGame;
	public static StartGameDelegate onPlayerDeath;

	public delegate void TakeDamageDelegate(float amt);
	public static TakeDamageDelegate onTakeDamage;


	public static void StartGame()
	{
		Debug.Log ("Start Game");
		if (onStartGame != null) 
			onStartGame();
		
	}
	public static void TakeDamage(float percent)
	{
		Debug.Log ("Take Damage: " + percent);
		if (onTakeDamage != null) 
			onTakeDamage(percent);

	}
	public static void PlayerDeath()
	{
		Debug.Log ("Player Died");
		if (onPlayerDeath != null) 
			onPlayerDeath();

	}
}
