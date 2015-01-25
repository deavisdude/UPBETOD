using UnityEngine;
using System.Collections;
using Photon;
public class MovePlayer : MonoBehaviour {
	public float speed = 10f;
	public float maxSpeed = 6;
	public float rotateConstant,shootOutSpeed,angle;
	public LayerMask layer,blackHoles;
	public Transform groundCheck,currentHole;
	public Rigidbody2D myBody;
	public bool isOrbit,facingRight;
	public int health,lives;
	
	void Start(){
		health = 1;
		facingRight = true;
		rotateConstant = 2f;
		shootOutSpeed = 75f;
		angle = 5f;
		myBody = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		float h = Input.GetAxis ("Horizontal");

						if (Input.GetKey (KeyCode.D) && rigidbody2D.velocity.x < maxSpeed)
								rigidbody2D.AddForce ((transform.right * (maxSpeed - rigidbody2D.velocity.x)) * Time.deltaTime * 60f);
						else if (Input.GetKey (KeyCode.A) && (-rigidbody2D.velocity.x < maxSpeed))
								rigidbody2D.AddForce ((-transform.right * (-(-maxSpeed - rigidbody2D.velocity.x))) * Time.deltaTime * 60f);

						if (Input.GetKeyDown (KeyCode.Space) && Physics2D.Linecast (transform.position, groundCheck.position, layer))
								rigidbody2D.AddForce (new Vector2 (0, speed), ForceMode2D.Impulse);


		
		// If the input is moving the player right and the player is facing left...
		if (h > 0 && !facingRight)
			// ... flip the player.
			Flip ();
		
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (h < 0 && facingRight)
			// ... flip the player.
			Flip ();
						if (Input.GetKeyUp (KeyCode.Space)) {
				isOrbit = false;
			
								rigidbody2D.AddForce ((Vector3.Normalize (transform.position - currentHole.position)) * shootOutSpeed, ForceMode2D.Impulse);
								currentHole = null;
				GetComponent<HingeJoint2D>().connectedBody = null;			
				isOrbit = false;
				GetComponent<HingeJoint2D>().enabled = false;
				}
	}
	public void Damage (int amount, Vector2 direction)
	{
		health -= amount;
		rigidbody2D.AddForce (direction * amount);
	}
	void OnTriggerStay2D(Collider2D collider)
	{
						Debug.Log (collider.tag);

						if (Input.GetKey (KeyCode.Space) && collider.tag == "Blackhole") {
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




