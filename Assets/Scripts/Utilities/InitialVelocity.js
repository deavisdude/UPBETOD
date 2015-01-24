#pragma strict

var startVelocity : Vector3;
var randomize : boolean = false;

function Start () {
if(randomize)	startVelocity = Random.insideUnitSphere * 10f;
if(rigidbody == null)	return;
yield WaitForFixedUpdate();
rigidbody.velocity += startVelocity;
}

function Update () {

}