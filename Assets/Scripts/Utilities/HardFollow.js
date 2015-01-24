#pragma strict

@script AddComponentMenu("Camera-Control/Hard Follow")

var target : Transform;
private var lastPosition : Vector3 = Vector3.zero;

function Start () {
lastPosition = target.position;
}

function Update () {
if(target == null)	return;
transform.position += (target.position - lastPosition);
lastPosition = target.position;
}