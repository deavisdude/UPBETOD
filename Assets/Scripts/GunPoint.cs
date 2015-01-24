using UnityEngine;
using System.Collections;

public class GunPoint : MonoBehaviour {

	public GameObject pointAt;
	public float bulletSpeed;
	/*float x;
	float y;
	float angle;
*/
	void Update () {
		Vector3 diff = (pointAt.transform.position - transform.position).normalized;
		
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		 
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

		/*
		if (Input.GetMouseButtonDown (0)) {
			//GetFirstActiveChild
			Transform activeBullet = null;
			for(int i = 0; i < transform.childCount;i++)
			{
				if(transform.GetChild(i).gameObject.activeSelf == false)
				{
					activeBullet = transform.GetChild (i);
					break;
				}

			}

			if(activeBullet != null)
			{
				activeBullet.gameObject.SetActive(true);
				activeBullet.rotation =  Quaternion.Euler(0f, 0f, rot_z);
				activeBullet.GetComponent<Rigidbody2D>().AddForce (transform.right * bulletSpeed,ForceMode2D.Impulse);
			}*/

		//}
	}
}
