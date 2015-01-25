using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D collider)
	{
		Debug.Log (collider.name);
		if (collider.tag == "Player") {
			collider.GetComponent<Shootv2>().typeOfShot = Random.Range(1,4);
			transform.parent.SendMessage("ImDead");
			Destroy(gameObject);		
		
		}
	}
}
