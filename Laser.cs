using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
[RequireComponent(typeof(Light))]
[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour {

	[SerializeField]float maxDistance = 300f;
	[SerializeField]float laserOffTime = .5f;
	LineRenderer lr;
	bool canFire;
	Light laserLight;
	[SerializeField]float fireDelay = 2f;

	void Awake()
	{
		lr = GetComponent<LineRenderer> ();
		laserLight = GetComponent<Light> ();
	}

	void Start()
	{
		lr.enabled = false;
		laserLight.enabled = false;
		canFire = true;
	}

	/*void Update()
	{
		Debug.DrawRay (transform.position, transform.TransformDirection (Vector3.forward) * maxDistance, Color.yellow);
	}*/

	Vector3 CastRay()
	{
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection (Vector3.forward) * maxDistance;

		if (Physics.Raycast (transform.position, fwd, out hit)) {
			Debug.Log ("We hit: " + hit.transform.name);

			SpawnExplosion (hit.point, hit.transform);

			return hit.point;
		}
		Debug.Log ("We missed...");
		return transform.position + (transform.forward * maxDistance);
	}

	void SpawnExplosion(Vector3 hitPosition, Transform target)
	{
		Explosion temp = target.GetComponent<Explosion> ();
		if(temp != null)
			temp.AddForce (hitPosition, transform);
		
	}



	public void FireLaser()
	{

		Vector3 pos = CastRay ();
		FireLaser (pos);
	}

	public void FireLaser(Vector3 targetPosition, Transform target = null)
	{
		if (canFire) 
		{
			if (target != null) 
			{
				SpawnExplosion (targetPosition, target);
			}

			//Vector3 aimPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


			lr.SetPosition (0, transform.position);
			lr.SetPosition (1, targetPosition);
			lr.enabled = true;
			canFire = false;
			laserLight.enabled = true;
			Invoke ("TurnOffLaser", laserOffTime);
			Invoke ("CanFire", fireDelay);

		}
	}

	void TurnOffLaser()
	{
		lr.enabled = false;
		laserLight.enabled = false;
	}

	public float Distance
	{
		get
		{ 
			return maxDistance;
		}
	}
	void CanFire()
	{
		canFire = true;
	}

}
