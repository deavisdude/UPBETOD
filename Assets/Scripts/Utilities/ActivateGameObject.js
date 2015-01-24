#pragma strict

var targetObject : GameObject;
var key : KeyCode;
var toggle : boolean = false;

function Start () {
if(key == KeyCode.None || targetObject == null){
	print("Undefined variable for GameObject activator. Disabling.");
	this.enabled = false;
}
}

function Update () {
if(Input.GetKeyDown(key) || (!toggle && Input.GetKeyUp(key)))
	targetObject.SetActive(!targetObject.activeSelf);
}