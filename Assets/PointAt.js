#pragma strict

var target : Transform;
var lockTo : Vector3 = Vector3.zero;


function Update () {
if(lockTo.sqrMagnitude <= 0f)	lockTo = transform.up;
transform.rotation = Quaternion.LookRotation(target.position - transform.position, lockTo);
}