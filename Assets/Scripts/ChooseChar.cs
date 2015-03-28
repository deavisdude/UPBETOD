using UnityEngine;
using System.Collections;

public class ChooseChar : MonoBehaviour {
	public static int[] character;
	public Transform[] charPos;
	public GameObject[] chars;
	public bool left,right;
	private Animator anim;
	int mySpot;
	// Use this for initialization
	void Start () {
		//charPos = new Transform[3];
		for(int i = 0; i < chars.Length; i++){
			anim = chars[i].GetComponentInChildren<Animator>();
			anim.SetBool ("Moving", true);
		}
		character = new int[3];
	}
	
	// Update is called once per frame 
	void Update () {
	/*	if (mySpot != 0 && character [mySpot - 1] != 1) {
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
		Debug.Log (mySpot);
		transform.position = charPos [mySpot].position;
		*/
	}
}
