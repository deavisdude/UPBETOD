using UnityEngine;
using System.Collections;
using Photon;
public class GunPoint : Photon.MonoBehaviour {
	Quaternion realRot;
	Vector3 realPosition;
	public GameObject pointAt;
	float x;
	float y;
	float angle;
	Vector3 shootDirection;

	void Update () {

		if (photonView.isMine) {
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
	}
	void FixedUpdate()
	{
		if (photonView.isMine) {
			
		} else {
			
			//velocity * time in his direction
				transform.position = new Vector3(realPosition.x,realPosition.y,-6.1f);
			//if(GetComponent<Rigidbody2D>() != null)
			//	transform.position += new Vector3(realVelocity.x,realVelocity.y,0) * Time.fixedDeltaTime;
			//transform.position = Vector2.Lerp(transform.position,rigidbody2D.velocity*Time.deltaTime,Time.deltaTime);
			
			//transform.rotation = Quaternion.Lerp (transform.rotation,realRot,.1f);
		}
	}
	void OnPhotonSerializeView(PhotonStream stream,PhotonMessageInfo info)
	{
		if (stream.isWriting) {
			/*if(GetComponent<MovePlayer>() != null && GetComponent<MovePlayer>().isOrbit)
			{
				stream.SendNext(GetComponent<MovePlayer>().currentHole.position);
			}
			else
			{*/
			stream.SendNext(transform.parent.position);
			//}
			stream.SendNext(transform.rotation);
			
			
		} else {
			realPosition = (Vector3)stream.ReceiveNext();
			realRot = (Quaternion)stream.ReceiveNext();
		}
		
	}
}
