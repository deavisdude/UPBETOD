using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	public float speed = 10f;
	public float maxSpeed = 6;
	public LayerMask layer;
	public Transform groundCheck;

	void Start(){

	}

	void Update () {

		if(Input.GetKey(KeyCode.D) && rigidbody2D.velocity.x < maxSpeed)
			rigidbody2D.AddForce((transform.right * (maxSpeed -rigidbody2D.velocity.x))*Time.deltaTime*60f);

		else if(Input.GetKey(KeyCode.A) && (-rigidbody2D.velocity.x < maxSpeed))
			rigidbody2D.AddForce((-transform.right* (-(-maxSpeed - rigidbody2D.velocity.x)))*Time.deltaTime*60f);

		if(Input.GetKeyDown(KeyCode.Space) && Physics2D.Linecast(transform.position, groundCheck.position,layer))
			rigidbody2D.AddForce(new Vector2(0,speed),ForceMode2D.Impulse);
	}
}
