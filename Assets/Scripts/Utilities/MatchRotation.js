#pragma strict

@script AddComponentMenu("Camera-Control/Match Rotation")

var target : Transform;

function Update () {
if(target != null)	transform.rotation = target.transform.rotation;
}