using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour 
{
	[SerializeField]Transform target; //Want to follow player's position
	[SerializeField]Vector3 defaultDistance = new Vector3(0f,2f, -10f); //How far behind is the camera
	[SerializeField]float distanceDamp = .15f; 
	//[SerializeField]float rotationDamp = 10f;

	Transform myT;

	public Vector3 velocity = Vector3.one;

	void Awake()
	{
		myT = transform;
	}

	void LateUpdate() //this happens after update, so player will move than camera will move
	{
		if (!FindTarget ())
			return;
		
		SmoothFollow ();
	}

	void SmoothFollow()
	{
		Vector3 toPos = target.position + (target.rotation * defaultDistance);
		Vector3 curPos = Vector3.SmoothDamp (myT.position, toPos, ref velocity, distanceDamp);
		myT.position = curPos;

		myT.LookAt (target, target.up);
	}
	bool FindTarget()
	{
		if (target == null)
		{
			GameObject temp = GameObject.FindGameObjectWithTag ("Player");
			if (temp != null)
				target = temp.transform;
		}

		if (target == null)
			return false;

		return true;
	}


}
