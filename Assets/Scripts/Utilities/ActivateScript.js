#pragma strict

var targetScript : Behaviour;
var key : KeyCode;
var toggle : boolean = false;

function Start () {
if(key == KeyCode.None || targetScript == null){
	print("Undefined variable for script activator. Disabling.");
	this.enabled = false;
}
}

function Update () {
if(Input.GetKeyDown(key) || (!toggle && Input.GetKeyUp(key)))
	targetScript.enabled = !targetScript.enabled;
}