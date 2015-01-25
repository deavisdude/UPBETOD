using UnityEngine;
using System.Collections;
using Photon;
public class NetworkScript : Photon.MonoBehaviour {
	public bool made;
	// Use this for initialization
	void Start () 
	{
					PhotonNetwork.ConnectUsingSettings ("v0.1");
	}

	void OnConnected()
	{
		RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom("myRoom", roomOptions, TypedLobby.Default);
	}
	void OnJoinedLobby()
	{
		RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom("myRoom", roomOptions, TypedLobby.Default);
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (PhotonNetwork.playerList [1]);
		Debug.Log (PhotonNetwork.connectionStateDetailed);
		/*if (PhotonNetwork.connected && PhotonNetwork.inRoom == false) {
			PhotonNetwork.JoinRandomRoom ();

		}*/
	}
	public void Onmake()
	{
		if(PhotonNetwork.inRoom)
		PhotonNetwork.Instantiate ("Character", transform.position, transform.rotation, 0);
	}

	void OnGUI(){

		if(GUI.Button (new Rect (0,0,Screen.width*.25f,Screen.height*.1f),"Spawn"))
		{
			Debug.Log("clci");
			
			PhotonNetwork.Instantiate ("Character", transform.position, transform.rotation, 0);
			
		}

	}

}