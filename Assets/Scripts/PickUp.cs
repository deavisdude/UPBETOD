using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

		void OnBecameInvisible() {
			Destroy(gameObject);
		}
		
		void OnTriggerEnter() {
			Destroy(gameObject);
		}
	}
	
