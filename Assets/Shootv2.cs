using UnityEngine;
using System.Collections;

/*public class Shootv2 : MonoBehaviour {
	
	public rigidbody2D bullet;
	public float velocity = 10.0f;

	void Update ()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			rigidbody2D newBullet = Instantiate(bullet,transform.position,transform.rotation) as rigidbody2D;
			newBullet.AddForce(transform.forward*velocity,ForceMode.VelocityChange);
		}
	}
}

public class Shootv2 : MonoBehaviour {
	public Rigidbody2D bullet; // Prefab of the bullet.
	public float bulletspeed = 20f; // The speed of the bullet
	public Vector3 Rotation; // Vector3 to save rotation
	
	void Update ()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			//Instantiate!
			Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
			bulletInstance.velocity = transform.forward * bulletspeed;
		}
	}
}*/


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