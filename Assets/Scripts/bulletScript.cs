using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {
	public int myDamage;
	public static float blackHoleMod;
	public float secondMod;
	// Use this for initialization
	void Start () {
		//secondMod = 2f;
		myDamage = 5;
	}
	
	// Update is called once per frame
	void Update ()
	{
		rigidbody2D.AddForce (transform.right * Time.deltaTime * 2);

		if (Input.GetKeyDown (KeyCode.G)) {
			blackHoleMod++;		
			Debug.Log(blackHoleMod);
		}
		if (Input.GetKeyDown (KeyCode.H)) {
			blackHoleMod +=100;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player") {
			collision.gameObject.GetComponent<MovePlayer>().Damage(myDamage,rigidbody2D.velocity);	
		
		}
	}
	void OnTriggerStay2D(Collider2D collider)
	{
	
		if (collider.tag == "Blackhole") {
			blackHoleMod = (secondMod/(transform.position - collider.transform.position).sqrMagnitude);
			//Debug.Log (blackHoleMod+"why");
		
			Vector3 shootDirection;
			shootDirection = collider.transform.position; //set direction to where the mouse is initially
			shootDirection.z = 0.0f; //Cure users somehow clicking in the z axis
			
			//shootDirection = Camera.main.ScreenToWorldPoint (shootDirection); 
			
			shootDirection -= transform.position;
			
			
			//	Debug.Log (pointAt.name + (pointAt.transform.position.x));
			//	Vector3 diff = pointAt.transform.position - transform.position;
			//shootDirection.Normalize ();
			
			float rot_z = Mathf.Atan2 (shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
			//transform.rotation = Quaternion.Euler (0f, 0f, rot_z);
			Debug.Log("kasjh");
			shootDirection.Normalize();
			rigidbody2D.AddForce(shootDirection*blackHoleMod, ForceMode2D.Impulse);
		}
	}
}
