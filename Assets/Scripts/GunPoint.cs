using UnityEngine;
using System.Collections;
public class GunPoint : MonoBehaviour {
	Quaternion realRot;
	Vector3 realPosition;
	public GameObject pointAt;
	float x;
	float y;
	float angle;
	Vector3 shootDirection;

	void Update () {

	
						shootDirection = Input.mousePosition; //set direction to where the mouse is initially
						shootDirection.z = 0.0f; //Cure users somehow clicking in the z axis
		
						shootDirection = Camera.main.ScreenToWorldPoint (shootDirection); 
		
						shootDirection = shootDirection - transform.position;


						//	Debug.Log (pointAt.name + (pointAt.transform.position.x));
						//	Vector3 diff = pointAt.transform.position - transform.position;
						shootDirection.Normalize ();
		
						float rot_z = Mathf.Atan2 (shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
						transform.rotation = Quaternion.Euler (0f, 0f, rot_z);
				}

	void FixedUpdate()
	{
		transform.position = new Vector3(transform.parent.position.x,transform.parent.position.y,-6.1f);
	}

}
