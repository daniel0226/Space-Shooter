using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(TrailRenderer))]
public class Thruster : MonoBehaviour 
{
	Light thrusterLight;
	//TrailRenderer tr;

	void Awake()
	{
		//tr = GetComponent<TrailRenderer> ();
		thrusterLight = GetComponent<Light> ();
	}

	void Start()
	{
		//tr.enabled = false;
		//thrusterLight.enabled = false;
		thrusterLight.intensity = 0;
	}

	/*public void Activate(bool activate = true)
	{
		if (activate) 
		{
			tr.enabled = true;
			thrusterLight.enabled = true;
		} 

		else 
		{
			tr.enabled = false;
			thrusterLight.enabled = false;
		}
	}*/

	public void Intensity(float inten)
	{
		thrusterLight.intensity = inten * 2f;
	}

}
