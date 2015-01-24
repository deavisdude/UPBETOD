#pragma strict

@script AddComponentMenu("Camera-Control/Dolly Zoom (Mouse)")

var speed : float = 1f;
var minDistance : float = 0.05f;
var maxDistance : float = 500f;
var button : KeyCode = KeyCode.Mouse0;
private var oldPosition : Vector3;

function Update () {
if(button != KeyCode.None && !Input.GetKey(button))	return;
oldPosition = transform.localPosition;
transform.localPosition *= 1 - Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
if(transform.localPosition.sqrMagnitude < minDistance * minDistance * 1.732 || transform.localPosition.sqrMagnitude > maxDistance * maxDistance * 1.732)	transform.localPosition = oldPosition;
//if(GetComponent("MouseOrbit"))	GetComponent(MouseOrbit).distance = transform.localPosition.magnitude;
if(GetComponent("MouseOrbitOmni"))	GetComponent(MouseOrbitOmni).distance = transform.localPosition.magnitude;
}