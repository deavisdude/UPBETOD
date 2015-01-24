using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour {



	void Update () {

		transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		transform.Translate (new Vector3(0,0,10));
	}
}
