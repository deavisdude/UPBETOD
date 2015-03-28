using UnityEngine;
using System.Collections;
using InControl;
//using Photon;
public class MovePlayer : MonoBehaviour {

	public InputDevice controller;

	public GameObject deathPrefab;

	Vector3 startPos;

	public float speed = 10f;
	public float maxSpeed = 6;
	public float rotateConstant,shootOutSpeed,angle;
	public LayerMask layer,blackHoles;
	public Transform groundCheck,currentHole;
	public Rigidbody2D myBody;
	public bool isOrbit,facingRight;
	public int health,lives;
	private Animator anim;
	public bool jump;
	void Start(){
		jump = false;
		anim = transform.GetChild(1).GetComponent<Animator> ();
		health = 30;
		facingRight = true;
		rotateConstant = 4.25f;
		shootOutSpeed = 110f;
		angle = 5f;
		myBody = GetComponent<Rigidbody2D> ();
		startPos = transform.position;
	}
	
	void Update () {
		float h = controller.LeftStickX.Value;
		if (h != 0) {
						anim.SetBool ("Moving", true);		
				} else {
			anim.SetBool("Moving",false);	
		}

						if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) < maxSpeed)
								GetComponent<Rigidbody2D>().AddForce ((h*transform.right * (maxSpeed - Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x))) * Time.deltaTime * 60f);
						

						if (controller.Action1.IsPressed && Physics2D.Linecast (transform.position, groundCheck.position, layer)) {
						GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, speed), ForceMode2D.Impulse);
			jump = true;
				}
		if (Physics2D.Linecast (transform.position, groundCheck.position, layer)) {
						jump = false;		
				} else {
			jump = true;		
		}
		if (jump == true) {
			anim.speed = 1;
						anim.SetBool ("Jump", true);
				} else {
			anim.SetBool ("Jump", false);

		}


		
		// If the input is moving the player right and the player is facing left...
		if (h > 0 && !facingRight)
			// ... flip the player.
			Flip ();
		
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (h < 0 && facingRight)
			// ... flip the player.
			Flip ();
		if (controller.Action1.WasReleased) {
			isOrbit = false;
			if(currentHole != null)
				GetComponent<Rigidbody2D>().AddForce ((Vector3.Normalize (transform.position - currentHole.position)) * shootOutSpeed, ForceMode2D.Impulse);
				currentHole = null;
				GetComponent<HingeJoint2D>().connectedBody = null;			
				isOrbit = false;
				GetComponent<HingeJoint2D>().enabled = false;
				}

		if(controller.Action2.IsPressed){
			//Respawn
			transform.position = startPos;
		}

		if(health <= 0){
			Destroy(this);
			Instantiate(deathPrefab, transform.position, transform.rotation);
		}
	}
	public void Damage (int amount, Vector2 direction)
	{
		health -= amount;
		GetComponent<Rigidbody2D>().AddForce (direction * amount);
	}
	void OnTriggerStay2D(Collider2D collider)
	{
						Debug.Log (collider.tag);

                        if (controller.Action1.IsPressed && collider.tag == "Blackhole")
                        {
								myBody.velocity = Vector2.zero;
								Debug.Log ("blah");
								myBody.Sleep (); 
								Vector2 destination = new Vector2 (collider.transform.position.x + Mathf.Cos (Time.time * rotateConstant), collider.transform.position.y + Mathf.Sin (Time.time * rotateConstant));
								transform.position = Vector2.Lerp (transform.position, destination, 1f);
			currentHole = collider.transform;
							/*	currentHole = collider.transform;
								GetComponent<HingeJoint2D> ().enabled = true;
								GetComponent<HingeJoint2D> ().connectedBody = currentHole.rigidbody2D;
								HingeJoint2D hinge = GetComponent<HingeJoint2D> ();
								JointMotor2D motor = hinge.motor;
								motor.motorSpeed = 100f;
								hinge.motor = motor;
								isOrbit=true;*/


						}
				

		}
		
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		//Debug.Log ("Flipped In Player ");
		//UI.SendMessage ("DoneFlip");
	}		
	}




