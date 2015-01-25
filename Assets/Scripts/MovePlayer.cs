using UnityEngine;
using System.Collections;
using Photon;
public class MovePlayer : Photon.MonoBehaviour {
	public float speed = 10f;
	public float maxSpeed = 6;
	public float rotateConstant,shootOutSpeed=200f,angle;
	public LayerMask layer,blackHoles;
	public Transform groundCheck,currentHole;
	public Rigidbody2D myBody;
	public bool isOrbit;
	
	void Start(){
	
		rotateConstant = 2f;
		//shootOutSpeed = 75f;
		angle = 5f;
		myBody = GetComponent<Rigidbody2D> ();
		PhotonNetwork.Instantiate ("crosshair", transform.position, transform.rotation, 0);
	}
	
	void Update () {
		if (photonView.isMine) {

						if (Input.GetKey (KeyCode.D) && rigidbody2D.velocity.x < maxSpeed)
								rigidbody2D.AddForce ((transform.right * (maxSpeed - rigidbody2D.velocity.x)) * Time.deltaTime * 60f);
						else if (Input.GetKey (KeyCode.A) && (-rigidbody2D.velocity.x < maxSpeed))
								rigidbody2D.AddForce ((-transform.right * (-(-maxSpeed - rigidbody2D.velocity.x))) * Time.deltaTime * 60f);

						if (Input.GetKeyDown (KeyCode.Space) && Physics2D.Linecast (transform.position, groundCheck.position, layer))
								rigidbody2D.AddForce (new Vector2 (0, speed), ForceMode2D.Impulse);


		
		
						if (Input.GetKeyUp (KeyCode.Space)) {
				isOrbit = false;
			
								rigidbody2D.AddForce ((Vector3.Normalize (transform.position - currentHole.position)) * shootOutSpeed, ForceMode2D.Impulse);
								currentHole = null;
				GetComponent<HingeJoint2D>().connectedBody = null;			
				isOrbit = false;
				GetComponent<HingeJoint2D>().enabled = false;
						}
				}
	}
	void OnTriggerStay2D(Collider2D collider)
	{
			if (photonView.isMine) {
						Debug.Log (collider.tag);

						if (Input.GetKey (KeyCode.Space) && collider.tag == "Blackhole") {
								/*	myBody.velocity = Vector2.zero;
								Debug.Log ("blah");
								myBody.Sleep (); 
								Vector2 destination = new Vector2 (collider.transform.position.x + Mathf.Cos (Time.time * rotateConstant), collider.transform.position.y + Mathf.Sin (Time.time * rotateConstant));
								transform.position = Vector2.Lerp (transform.position, destination, 1f);
			*/
								currentHole = collider.transform;
								GetComponent<HingeJoint2D> ().enabled = true;
								GetComponent<HingeJoint2D> ().connectedBody = currentHole.rigidbody2D;
								HingeJoint2D hinge = GetComponent<HingeJoint2D> ();
								JointMotor2D motor = hinge.motor;
								motor.motorSpeed = 100f;
								hinge.motor = motor;
				isOrbit=true;

								//rigidbody2D.AddForce(transform.right*speed);

								//transform.RotateAround(new Vector2(currentHole.position.x,currentHole.position.y),new Vector2(transform.position.x,transform.position.y),angle);
						}
				} else {
				

		}
		
		
	}

}


