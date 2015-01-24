using UnityEngine;
using System.Collections;
using Photon;

public class NetworkChar : Photon.MonoBehaviour {
	Vector3 realPosition = Vector3.zero;
	Vector3 sendingPos = Vector3.zero;
	public float lagMod;
	bool haveMove,inOrbit;

	Vector2 realVelocity;
	Quaternion realRot = Quaternion.identity;
	// Use this for initialization
	void Start () {
		if (GetComponent<MovePlayer> () != null) {
						haveMove = true;
			inOrbit = GetComponent<MovePlayer>().isOrbit;
		
				} else
						haveMove = false;
		sendingPos = transform.position;
		lagMod = 5f;


	}
	
	// Update is called once per frame
	void Update () {
		if (haveMove &&inOrbit) {
						sendingPos = GetComponent<MovePlayer> ().currentHole.position;
				} else {
			sendingPos = transform.position;		
		}
	}
	void FixedUpdate()
	{
		if (photonView.isMine) {
			
		} else {

			//velocity * time in his direction
			if (haveMove &&inOrbit) 
				transform.position = realPosition;
			else
			transform.position = Vector2.Lerp(transform.position,realPosition,.1f);
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
			stream.SendNext(sendingPos);
			//}
			stream.SendNext(transform.rotation);


				} else {
			realPosition = (Vector3)stream.ReceiveNext();
			realRot = (Quaternion)stream.ReceiveNext();
			Debug.Log(realVelocity+",After");
		}

	}
}
