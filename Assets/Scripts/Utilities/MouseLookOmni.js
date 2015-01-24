#pragma strict

@script AddComponentMenu("Camera-Control/MouseLook Omni");

var speed : int = 10;
var lockMouse : boolean = true;

function Start(){	if(lockMouse)	Screen.lockCursor = true;	}

function Update () {
transform.Rotate(-Input.GetAxisRaw("Mouse Y") * speed, Input.GetAxisRaw("Mouse X") * speed, 0);
}