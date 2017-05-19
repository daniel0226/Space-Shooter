using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour 
{
	[SerializeField]Laser[] laser;

	void Update()
	{
		
		if (Input.GetButton("Fire1")) 
		{
			foreach (Laser val in laser) 
			{
				val.FireLaser ();
			}
		}
	}


}
