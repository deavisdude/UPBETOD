using UnityEngine;
using System.Collections;
using InControl;

public class Shootv2 : MonoBehaviour {

	public Rigidbody2D bullet,bulletStraight,Cannon; // Prefab of the bullet.
	Vector3 shootDirection; //Point to initially shoot towards
	public float speed;
	public bool shootToggle;
	public float fireRate = 1;
	public float rot_z;
	private float afireRate;
    public Transform blastStart;
	public int typeOfShot;

	public InputDevice controller;
	

	void Start()
	{
		shootToggle = true;
		//index 0 = Standard ammon, 1 = triShot , 2 = StraightShot, 3 = CannonShot, 4 = Machine Gun
		typeOfShot = 0;
	}

	void Update ()
	{
       /* if (transform.parent.transform.localScale.x < 0) { 
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        }
        else
        {
            transform.localScale = transform.parent.localScale;
        }*/
		if(GetComponentInParent<MovePlayer>().facingRight){
			shootDirection = new Vector2(controller.RightStickX.Value, controller.RightStickY.Value);
		}else{
        	shootDirection = new Vector2(-controller.RightStickX.Value, controller.RightStickY.Value); //set direction to where the mouse is initially
		}
		shootDirection.z = 0.0f; //Cure users somehow clicking in the z axis
		
		//shootDirection = Camera.main.ScreenToWorldPoint (shootDirection); 
		
		//shootDirection = shootDirection - transform.position;
		
		
		//	Debug.Log (pointAt.name + (pointAt.transform.position.x));
		//	Vector3 diff = pointAt.transform.position - transform.position;
		//shootDirection.Normalize ();
		
		rot_z = Mathf.Atan2 (shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rot_z);
		GameObject.Find("ArmLeft").GetComponent<Transform>().rotation = Quaternion.Euler (0f, 0f, rot_z/8);
		GameObject.Find("ArmRight").GetComponent<Transform>().rotation = Quaternion.Euler (0f, 0f, rot_z/8);
		//Debug, 1-4 change ammo type
		if (controller.DPadUp.IsPressed) {
				typeOfShot = 0;		
		}
		if (controller.DPadLeft.IsPressed) {
			typeOfShot = 1;		
		}
		if (controller.DPadRight.IsPressed) {
			typeOfShot = 2;		
		}
		if (controller.DPadDown.IsPressed) {
			typeOfShot = 3;		
		}
		if (shootToggle) {
			if (controller.RightTrigger.IsPressed) {
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

		Rigidbody2D bulletInstance = Instantiate (bullet, blastStart.position, transform.rotation) as Rigidbody2D;
		bulletInstance.transform.eulerAngles = (new Vector3(0,0,rot_z+rotMod));
		bulletInstance.AddRelativeForce (new Vector2(750*shotSpeed, 0));
		if (typeOfShot == 3) {
			int color = Random.Range (0,4);
			if(color == 0)
			bulletInstance.gameObject.GetComponent<SpriteRenderer>().color = Color.green;		
			if(color == 1)
				bulletInstance.gameObject.GetComponent<SpriteRenderer>().color = Color.red;		

			if(color == 2)
				bulletInstance.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;		

			if(color == 3)
				bulletInstance.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;		

		}

		Physics2D.IgnoreCollision (transform.parent.GetComponent<Collider2D>(), bulletInstance.GetComponent<Collider2D>());
		shootToggle = false;
		
		if (IsInvoking () == false) {
			Invoke ("shootCD", fireRate);
		}
	}
	void ShootBullet(float shotSpeed, Vector3 direction)
	{
		
		Rigidbody2D bulletInstance = Instantiate (bulletStraight, blastStart.position, transform.rotation) as Rigidbody2D;
		bulletInstance.transform.eulerAngles = (new Vector3(0,0,rot_z));
		bulletInstance.AddRelativeForce (new Vector2(750*shotSpeed, 0));
		
		
		Physics2D.IgnoreCollision (transform.parent.GetComponent<Collider2D>(), bulletInstance.GetComponent<Collider2D>());
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
		
		
		Physics2D.IgnoreCollision (transform.parent.GetComponent<Collider2D>(), bulletInstance.GetComponent<Collider2D>());
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