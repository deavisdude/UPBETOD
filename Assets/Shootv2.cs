using UnityEngine;
using System.Collections;


public class Shootv2 : MonoBehaviour {

	public Rigidbody2D bullet; // Prefab of the bullet.

	Vector3 shootDirection; //Point to initially shoot towards
	public float speed = 10f;
	
	void Update ()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			shootDirection = Input.mousePosition; //set direction to where the mouse is initially
			shootDirection.z = 0.0f; //Cure users somehow clicking in the z axis

			shootDirection = Camera.main.ScreenToWorldPoint(shootDirection); 

			shootDirection = shootDirection-transform.position;

			Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
		}
	}
}