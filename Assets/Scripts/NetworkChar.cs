using UnityEngine;
using System.Collections;
using Photon;

public class NetworkChar : Photon.MonoBehaviour {
	Vector3 realPosition = Vector3.zero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (photonView.isMine) {
			
				} else {
			transform.position = Vector2.Lerp(transform.position,realPosition,.1f);
				
		}
	}
	void OnPhotonSerializeView(PhotonStream stream,PhotonMessageInfo info)
	{
		if (stream.isWriting) {
			stream.SendNext(transform.position);
				} else {
			realPosition = (Vector3)stream.ReceiveNext();
		}

	}
}
