using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {

	public EventSystem eventSystem;
	List<Selectable> buttons;
	public Selectable ButtonHelp;
	public Selectable ButtonPlay;
	public Selectable ButtonExit;

	Selectable SelectedButton;
	int selectButtonIndex = 1;
	// Use this for initialization
	void Start () {
		buttons = new List<Selectable>();
		buttons.Add (ButtonHelp);
		buttons.Add (ButtonPlay);
		buttons.Add (ButtonExit);

		SelectedButton = buttons [1];
		//Debug.Log (buttons.Count);

		//eventSystem.firstSelectedGameObject(selectableUI.)
	}

	// Update is called once per frame
	void Update () {

		//InputTimer();
		//new WaitForSeconds (4);
		Debug.Log ("index:" + selectButtonIndex);

		SelectedButton = buttons [selectButtonIndex];
		eventSystem.SetSelectedGameObject(SelectedButton.gameObject, new BaseEventData(eventSystem));
		float h = Input.GetAxisRaw("Horizontal");

		if(h >= 1){
			h = 0;
			Move (false,true);
			
		}else if(h <= -.99){
			Debug.Log (h);
			h = 0;
			Move(true,false);
			
		}
	}
	void GetInput(){
		//StartCoroutine (wait ());
		Debug.Log ("Input");

	}

	IEnumerator wait(){

		yield return new WaitForSeconds(1);
		print("finish");
	}
	void Move(bool left, bool right){
		if (left) {
			if (selectButtonIndex == 0) {
				selectButtonIndex = 0;
			}
			if (selectButtonIndex == 1) {
				selectButtonIndex = 0;
			}
			if (selectButtonIndex == 2) {
				selectButtonIndex = 1;
			}
		}
		if (right) {
			if (selectButtonIndex == 0) {
				selectButtonIndex = 1;
			}
			if (selectButtonIndex == 1) {
				selectButtonIndex = 2;
			}
			if (selectButtonIndex == 2) {
				selectButtonIndex = 2;
			}
		}
	
	}
}
