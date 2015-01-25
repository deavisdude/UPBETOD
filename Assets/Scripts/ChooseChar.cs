using UnityEngine;
using System.Collections;

public class ChooseChar : MonoBehaviour {
	public static int[] character;
	public Transform[] charPos;
	public bool left,right;
	int mySpot;
	// Use this for initialization
	void Start () {
		//charPos = new Transform[3];
		character = new int[3];
	}
	
	// Update is called once per frame 
	void Update () {
		if (mySpot != 0 && character [mySpot - 1] != 1) {
						left = true;		
				} else {
			left = false;		
		}
		if (mySpot != 2 && character [mySpot + 1] != 1) {
						right = true;		
				} else {
			right = false;		
		}
	if (Input.GetKeyDown(KeyCode.LeftArrow)&& left == true) {
			character[mySpot] = 0;
			mySpot--;
			character[mySpot] = 1;
				
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)&& right == true) {
			character[mySpot] = 0;
			mySpot++;
			character[mySpot] = 1;
			
		}
		transform.position = charPos [mySpot].position;

	}
}
