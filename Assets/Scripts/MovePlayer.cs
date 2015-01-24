using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	public float speed = 10f;
	public float maxSpeed = 6;

	void Start(){

	}

	void Update () {
		if(Input.GetKey(KeyCode.D) && rigidbody2D.velocity.x < maxSpeed)
			rigidbody2D.AddForce(transform.right * (maxSpeed -rigidbody2D.velocity.x));

		else if(Input.GetKey(KeyCode.A) && (-rigidbody2D.velocity.x < maxSpeed))
			rigidbody2D.AddForce(-transform.right* (-(-maxSpeed - rigidbody2D.velocity.x)));
		//if(rigidbody2D.velocity.x > 6)
			//rigidbody2D.velocity = new Vector2(6,rigidbody2D.velocity.y);


	}
}
