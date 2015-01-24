#pragma strict
@script AddComponentMenu("Camera-Control/Mouse Orbit Omni")

var target : Transform;
var speed : float = 1f;
var distance : float = 10f;
var offset : Vector3 = Vector3.zero;
private var offsetRotation : Quaternion = Quaternion.identity;

function Start(){
offsetRotation = transform.rotation;
}

function LateUpdate () {
if(target == null)	return;
offsetRotation *= Quaternion.Euler(-Input.GetAxis("Mouse Y") * speed, Input.GetAxis("Mouse X") * speed, 0);
transform.position = offsetRotation * Vector3(0, 0, -distance) + target.position + transform.rotation * offset;
transform.rotation = Quaternion.LookRotation(target.position - transform.position + transform.rotation * offset, transform.up);
}