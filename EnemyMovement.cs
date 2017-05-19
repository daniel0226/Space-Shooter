using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour 
{
	[SerializeField]Transform target;
	[SerializeField]float rotationalDamp = .5f;
	[SerializeField]float movementSpeed = 10f;

	[SerializeField]float rayCastOffset = 2.5f;
	[SerializeField]float detectionDistance = 20f;

	void OnEnable()
	{
		EventManager.onPlayerDeath += FindMainCamera;
	}

	void OnDisable()
	{
		EventManager.onPlayerDeath -= FindMainCamera;
	}

	void Update()
	{
		if (!FindTarget ())
			return;
		
		PathFinding ();
		//Turn ();
		Move ();
	}

	void Move()
	{
		transform.position += transform.forward * Time.deltaTime * movementSpeed;
	}

	void Turn()
	{
		Vector3 pos = target.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation (pos);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationalDamp);
	}

	void PathFinding()
	{
		RaycastHit hit;
		Vector3 raycastOffsets = Vector3.zero;

		Vector3 left = transform.position - transform.right * rayCastOffset;
		Vector3 right = transform.position + transform.right * rayCastOffset;
		Vector3 up  = transform.position + transform.up * rayCastOffset;
		Vector3 down  = transform.position - transform.up * rayCastOffset;

		if (Physics.Raycast (left, transform.forward, out hit, detectionDistance)) 
		{
			raycastOffsets += Vector3.right;
		}
		else if (Physics.Raycast (right, transform.forward, out hit, detectionDistance)) 
		{
			raycastOffsets -= Vector3.right;
		}
		else if (Physics.Raycast (up, transform.forward, out hit, detectionDistance)) 
		{
			raycastOffsets -= Vector3.up;
		}
		else if (Physics.Raycast (down, transform.forward, out hit, detectionDistance)) 
		{
			raycastOffsets += Vector3.up;
		}

		if (raycastOffsets != Vector3.zero)
			transform.Rotate (raycastOffsets * 5f * Time.deltaTime);
		else 
		{
			Turn ();
		}


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

	void FindMainCamera()
	{
		target = GameObject.FindGameObjectWithTag ("MainCamera").transform;
	}
}
