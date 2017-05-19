using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour 
{
	[SerializeField]float minScale = .8f;
	[SerializeField]float maxScale = 1.2f;
	[SerializeField]float rotationOffset = 50f;
	[SerializeField]GameObject explosion; //make it an array if you want multiple explosions

	Transform myT;

	Vector3 randomRotation;

	void Awake()
	{
		myT = transform;
	}
		
	void Start()
	{
		//random size for asteroid
		Vector3 scale = Vector3.one;
		scale.x = Random.Range (minScale, maxScale);
		scale.y = Random.Range (minScale, maxScale);
		scale.z = Random.Range (minScale, maxScale); //size range from .8 to 1.2

		myT.localScale = scale;

		//random rotation
		randomRotation.x = Random.Range (-rotationOffset, rotationOffset);
		randomRotation.y = Random.Range (-rotationOffset, rotationOffset);
		randomRotation.z = Random.Range (-rotationOffset, rotationOffset);
	}
	void Update() //Make the asteroid rotate
	{
		myT.Rotate (randomRotation * Time.deltaTime);
	}


}
