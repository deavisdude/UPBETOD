#pragma strict

@script AddComponentMenu("Camera-Control/Dolly Zoom")

var speed : float = 1f;
var min : float = 0.05f;
var max : float = 500f;
private var oldPosition : Vector3;

function Update () {
oldPosition = transform.localPosition;
transform.localPosition *= 1 - Input.GetAxis("Vertical") * speed * Time.deltaTime;
if(transform.localPosition.sqrMagnitude < min * min * 1.732 || transform.localPosition.sqrMagnitude > max * max * 1.732)	transform.localPosition = oldPosition;
//if(GetComponent("MouseOrbit"))	GetComponent(MouseOrbit).distance = transform.localPosition.magnitude;
if(GetComponent("MouseOrbitOmni"))	GetComponent(MouseOrbitOmni).distance = transform.localPosition.magnitude;
}