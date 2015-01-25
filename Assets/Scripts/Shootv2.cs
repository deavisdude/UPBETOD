using UnityEngine;
using System.Collections;
public class Shootv2 : MonoBehaviour {

	public Rigidbody2D bullet; // Prefab of the bullet.

	Vector3 shootDirection; //Point to initially shoot towards
	public float speed;
	public bool shootToggle;
	public float fireRate = 1;
	private float afireRate;
	public int typeOfShot;
	void Start()
	{
		shootToggle = true;
		//index 0 = Standard ammon, 1 = triShot , 2 = StraightShot, 3 = CannonShot, 4 = Machine Gun
		typeOfShot = 0;
	}

	void Update ()
	{
		shootDirection = Input.mousePosition; //set direction to where the mouse is initially
		shootDirection.z = 0.0f; //Cure users somehow clicking in the z axis
		
		shootDirection = Camera.main.ScreenToWorldPoint (shootDirection); 
		
		shootDirection = shootDirection - transform.position;
		
		
		//	Debug.Log (pointAt.name + (pointAt.transform.position.x));
		//	Vector3 diff = pointAt.transform.position - transform.position;
		shootDirection.Normalize ();
		
		float rot_z = Mathf.Atan2 (shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rot_z);
		//Debug, 1-4 change ammo type
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
				typeOfShot = 0;		
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			typeOfShot = 1;		
		}
		if (shootToggle) {
			if (Input.GetButtonDown ("Fire1")) {
				if (typeOfShot == 0) {
					shootDirection = Input.mousePosition; //set direction to where the mouse is initially
					shootDirection.z = 0.0f; //Cure users somehow clicking in the z axis

					shootDirection = Camera.main.ScreenToWorldPoint (shootDirection); 

					shootDirection = shootDirection - transform.position;
					shootDirection.Normalize ();
					Rigidbody2D bulletInstance = Instantiate (bullet, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2 (shootDirection.x * speed, shootDirection.y * speed);
					
					Debug.Log (bulletInstance.velocity.ToString ());
					Physics2D.IgnoreCollision (transform.parent.collider2D, bulletInstance.collider2D);
					shootToggle = false;

					if (IsInvoking () == false) {
							Invoke ("shootCD", fireRate);
					}
				}
				else if(typeOfShot ==1)
				{
					shootDirection = Input.mousePosition; //set direction to where the mouse is initially
					shootDirection.z = 0.0f; //Cure users somehow clicking in the z axis
					
					shootDirection = Camera.main.ScreenToWorldPoint (shootDirection); 
					
					shootDirection = shootDirection - transform.position;
					shootDirection.Normalize ();

					Rigidbody2D bulletInstance = Instantiate (bullet, transform.position, Quaternion.identity) as Rigidbody2D;
					Rigidbody2D bulletInstance2 = Instantiate (bullet, transform.position, Quaternion.identity * Quaternion.Euler(0, 0, 30)) as Rigidbody2D;
					Rigidbody2D bulletInstance3 = Instantiate (bullet, transform.position, Quaternion.identity * Quaternion.Euler(0, 0, 30)) as Rigidbody2D;
					bulletInstance.velocity = new Vector2 (0, speed);
					bulletInstance2.velocity = new Vector2 (0, speed);
					bulletInstance3.velocity = new Vector2 (0, speed);
					
					Physics2D.IgnoreCollision (transform.parent.collider2D, bulletInstance.collider2D);
					Physics2D.IgnoreCollision (transform.parent.collider2D, bulletInstance2.collider2D);
					Physics2D.IgnoreCollision (transform.parent.collider2D, bulletInstance3.collider2D);

					shootToggle = false;
					
					if (IsInvoking () == false) {
						Invoke ("shootCD", fireRate);
					}
				}
			}
		}
		}


void shootCD()
{
	shootToggle = true;
}
}