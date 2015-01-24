using UnityEngine;
using System.Collections;

public class GunPoint : MonoBehaviour {

	public GameObject pointAt;
	float x;
	float y;
	float angle;

	void Update () {
		Vector3 diff = pointAt.transform.position - transform.position;
		diff.Normalize();
		
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
	}
}
