using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public GameObject exPrefab;

	public bool crouching= false;

	public int speed = 5;
	public float jumpPower = 400f;
	Vector2 acc;

	Vector3 normalScale;
	Vector3 crouchingScale;

	Quaternion rightRotation;
	Quaternion leftRotation;

	Animator anim;

	CrouchButton cb;

	//Joystick joy;


	void Start(){
		anim = GetComponent<Animator>();
		normalScale = this.transform.localScale;
		crouchingScale = new Vector3(this.transform.localScale.x*0.63f,(this.transform.localScale.y)*0.63f, this.transform.localScale.z);

		//joy = (Joystick) GameObject.Find("Joystick").GetComponent(typeof(Joystick));
		cb = (CrouchButton) GameObject.Find("CrouchButton").GetComponent(typeof(CrouchButton));

		rightRotation = transform.localRotation;
		leftRotation = new Quaternion(transform.localRotation.x, 180f, transform.localRotation.z, transform.localRotation.w);
	}

	float prevX;
	float XVelocity = 0;

	void Update () {
		prevX = transform.position.x;

		acc = new Vector2(speed*Joystick.VJRnormals.x*Time.deltaTime, 0f);
		//acc = new Vector2(speed*Input.GetAxis("Horizontal")*Time.deltaTime, 0);

		if(XVelocity != 0){
			anim.SetBool("Running", true);
		}else{
			anim.SetBool("Running", false);
		}

 		
		//CrouchButton cb = (CrouchButton) GameObject.Find("Player").GetComponent(typeof(CrouchButton));

		if(crouching || cb.pressed){
			transform.localScale = crouchingScale;
			acc*=0.63f;
		}else{
			transform.localScale = normalScale;
			if(Input.GetButtonDown("Jump") && rigidbody2D.velocity.y == 0){
				Jump();
			}else{
				anim.SetBool("Jump", false);
			}
		}

		/*if(Input.GetButton("Crouch")){
			crouching = true;
		}else{
			crouching = false;
		}*/


		transform.position += (Vector3) acc;
		acc= new Vector2();

		XVelocity = (transform.position.x - prevX)/Time.deltaTime;

		if(XVelocity < 0){
			transform.rotation = new Quaternion(0f,180f,0f,0f);
		}else if(XVelocity > 0){
			transform.rotation = new Quaternion(0f,0f,0f,0f);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "apple"){
			Instantiate(exPrefab, this.transform.position, this.transform.rotation);
			Destroy(this.gameObject);
			for(int i=0; i < GameObject.FindGameObjectsWithTag("apple").Length; i++){
				Destroy((GameObject) GameObject.FindGameObjectsWithTag("apple").GetValue(i));
			}
		}
	}
	public void Jump(){
		if(rigidbody2D.velocity.y == 0){
			rigidbody2D.AddForce(new Vector2(0, jumpPower));
			anim.SetBool("Jump", true);
		}
	}

}
