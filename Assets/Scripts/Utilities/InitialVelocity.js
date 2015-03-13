#pragma strict

var startVelocity : Vector3;
var randomize : boolean = false;

function Start () {
if(randomize)	startVelocity = Random.insideUnitSphere * 10f;
if(GetComponent.<Rigidbody>() == null)	return;
yield WaitForFixedUpdate();
GetComponent.<Rigidbody>().velocity += startVelocity;
}

function Update () {

}