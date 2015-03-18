using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;

public class Controllers : MonoBehaviour {	

	public GameObject playerPrefab;
	public static List<InputDevice> playerControllers = new List<InputDevice>();
	public InputDevice activeDevice;

	void Update () {
		bool isControllerKnown = false;
		activeDevice = InputManager.ActiveDevice;
		foreach(InputDevice dev in playerControllers){
			if(activeDevice.Equals(dev)){
				isControllerKnown = true;
			}
		}
		if(!isControllerKnown && activeDevice.AnyButton.WasPressed){
			playerControllers.Add(activeDevice);
			SpawnPlayer(activeDevice);
		}
	}

	void SpawnPlayer(InputDevice pcontroller){
		GameObject player = Instantiate(playerPrefab)as GameObject;
		Debug.Log(pcontroller.Name);
		player.GetComponent<MovePlayer>().controller = pcontroller;
		player.GetComponentInChildren<Shootv2>().controller = pcontroller;
	}
}
