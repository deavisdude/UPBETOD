using UnityEngine;
using System.Collections;
using Photon;
public class NetworkScript : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
				PhotonNetwork.ConnectUsingSettings ("v4.2");
				
				}
		
	void OnPhotonRandomJoinFailed()
	{
		PhotonNetwork.CreateRoom ("bleh");
	}
	// Update is called once per frame
	void Update () {
		Debug.Log (PhotonNetwork.connectionStateDetailed);
	if (PhotonNetwork.connected && PhotonNetwork.inRoom == false) {
			PhotonNetwork.JoinRandomRoom ();

		}
						if (Input.GetKeyDown (KeyCode.Alpha1)) {
						}

	}
	void OnGUI()
	{
		if(GUI.Button (new Rect (0,0,Screen.width*.25f,Screen.height*.1f),"Spawn"))
		{
			Debug.Log("clci");

			PhotonNetwork.Instantiate ("Character", transform.position, transform.rotation, 0);

		}
	}
}
