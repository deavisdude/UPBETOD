using UnityEngine;
using System.Collections;
public class Shootv2 : MonoBehaviour {

	public Rigidbody2D bullet,bulletStraight,Cannon; // Prefab of the bullet.
	Vector3 shootDirection; //Point to initially shoot towards
	public float speed;
	public bool shootToggle;
	public float fireRate = 1;
	public float rot_z;
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
		
		rot_z = Mathf.Atan2 (shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rot_z);
		//Debug, 1-4 change ammo type
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
				typeOfShot = 0;		
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			typeOfShot = 1;		
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			typeOfShot = 2;		
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			typeOfShot = 3;		
		}
		if (shootToggle) {
			if (Input.GetButtonDown ("Fire1")) {
				if (typeOfShot == 0) {
					shootDirection = Input.mousePosition; //set direction to where the mouse is initially
					shootDirection.z = 0.0f; //Cure users somehow clicking in the z axis
					
					shootDirection = Camera.main.ScreenToWorldPoint (shootDirection); 
					
					shootDirection = shootDirection - transform.position;
					shootDirection.Normalize ();
					ShootBullet(speed*3,shootDirection,0f);
					fireRate = .8f;

				}
				else if(typeOfShot ==1)
				{
					shootDirection = Input.mousePosition; //set direction to where the mouse is initially
					shootDirection.z = 0.0f; //Cure users somehow clicking in the z axis
					
					shootDirection = Camera.main.ScreenToWorldPoint (shootDirection); 
					
					shootDirection = shootDirection - transform.position;
					ShootBullet(speed *3f,shootDirection,-10f);
					ShootBullet(speed*3f,shootDirection,0f);
					ShootBullet(speed*3f,shootDirection,10f);
					shootToggle = false;
					fireRate = .8f;

			
				}
				else if(typeOfShot == 2)
				{

					shootDirection = Input.mousePosition; //set direction to where the mouse is initially
					shootDirection.z = 0.0f; //Cure users somehow clicking in the z axis
					
					shootDirection = Camera.main.ScreenToWorldPoint (shootDirection); 
					
					shootDirection = shootDirection - transform.position;
					ShootCannon(speed,shootDirection);
					shootToggle = false;
					fireRate = .8f;
				}
			
			}
			if(Input.GetMouseButton(0))
			{
				if(typeOfShot == 3)
				{
					shootDirection = Input.mousePosition; //set direction to where the mouse is initially
					shootDirection.z = 0.0f; //Cure users somehow clicking in the z axis
					
					shootDirection = Camera.main.ScreenToWorldPoint (shootDirection); 
					
					shootDirection = shootDirection - transform.position;
					shootDirection.Normalize ();
					ShootBullet(speed*3,shootDirection,0f);
					fireRate = .1f;
				}
			}
		}
		}

void ShootBullet(float shotSpeed, Vector3 direction, float rotMod)
	{

		Rigidbody2D bulletInstance = Instantiate (bullet, transform.position, transform.rotation) as Rigidbody2D;
		bulletInstance.transform.eulerAngles = (new Vector3(0,0,rot_z+rotMod));
		bulletInstance.AddRelativeForce (new Vector2(750*shotSpeed, 0));
		

		Physics2D.IgnoreCollision (transform.parent.collider2D, bulletInstance.collider2D);
		shootToggle = false;
		
		if (IsInvoking () == false) {
			Invoke ("shootCD", fireRate);
		}
	}
	void ShootBullet(float shotSpeed, Vector3 direction)
	{
		
		Rigidbody2D bulletInstance = Instantiate (bulletStraight, transform.position, transform.rotation) as Rigidbody2D;
		bulletInstance.transform.eulerAngles = (new Vector3(0,0,rot_z));
		bulletInstance.AddRelativeForce (new Vector2(750*shotSpeed, 0));
		
		
		Physics2D.IgnoreCollision (transform.parent.collider2D, bulletInstance.collider2D);
		shootToggle = false;
		
		if (IsInvoking () == false) {
			Invoke ("shootCD", fireRate);
		}
	}
	void ShootCannon(float shotSpeed, Vector3 direction)
	{
		Rigidbody2D bulletInstance = Instantiate (Cannon, transform.position, transform.rotation) as Rigidbody2D;
		bulletInstance.transform.eulerAngles = (new Vector3(0,0,rot_z));
		bulletInstance.AddRelativeForce (new Vector2(750*speed, 0));
		
		
		Physics2D.IgnoreCollision (transform.parent.collider2D, bulletInstance.collider2D);
		shootToggle = false;
		
		if (IsInvoking () == false) {
			Invoke ("shootCD", fireRate);
		}
	}
void shootCD()
{
	shootToggle = true;
}
}