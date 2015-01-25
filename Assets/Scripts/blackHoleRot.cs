using UnityEngine;
using System.Collections;

public class blackHoleRot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (RotateMe ());
	}
	
	// Update is called once per frame
	void Update () {
	}
	IEnumerator RotateMe()
	{
		while (true) {
			transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z + 5);

			yield return new WaitForSeconds(.01f);
		}

	}
}
