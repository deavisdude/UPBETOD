#pragma strict

var rotation : Vector3 = Vector3.zero;

function Update () {
transform.Rotate(rotation * Time.deltaTime);
}