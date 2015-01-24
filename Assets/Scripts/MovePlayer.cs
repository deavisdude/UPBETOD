using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	public float speed = 10f;
	public float maxSpeed = 6;
	public float rotateConstant,shootOutSpeed;
	public LayerMask layer,blackHoles;
	public Transform groundCheck,currentHole;
	public Rigidbody2D myBody;

	
	void Start(){
		rotateConstant = 2f;
		shootOutSpeed = 75f;
		myBody = GetComponent<Rigidbody2D> ();

	}
	
	void Update () {

		if(Input.GetKey(KeyCode.D) && rigidbody2D.velocity.x < maxSpeed)
			rigidbody2D.AddForce((transform.right * (maxSpeed -rigidbody2D.velocity.x))*Time.deltaTime*60f);

		else if(Input.GetKey(KeyCode.A) && (-rigidbody2D.velocity.x < maxSpeed))
			rigidbody2D.AddForce((-transform.right* (-(-maxSpeed - rigidbody2D.velocity.x)))*Time.deltaTime*60f);

		if(Input.GetKeyDown(KeyCode.Space) && Physics2D.Linecast(transform.position, groundCheck.position,layer))
			rigidbody2D.AddForce(new Vector2(0,speed),ForceMode2D.Impulse);


		
		
		if(Input.GetKeyUp(KeyCode.Space))
		{
			
			
			rigidbody2D.AddForce((Vector3.Normalize(transform.position-currentHole.position)) * shootOutSpeed,ForceMode2D.Impulse);
			currentHole = null;
			
		}
	}
	void OnTriggerStay2D(Collider2D collider)
	{
		Debug.Log ("blah");
		if (Input.GetKey (KeyCode.Space) && collider.tag == "BlackHole") {
			myBody.velocity = Vector2.zero;
			currentHole = collider.transform;
			myBody.Sleep (); 
			Vector2 destination = new Vector2(collider.transform.position.x + Mathf.Cos(Time.time*rotateConstant),collider.transform.position.y + Mathf.Sin(Time.time*rotateConstant));
			transform.position = Vector2.Lerp(transform.position, destination, 1f);
			
			
		}

	}
}


