#pragma strict

var key : KeyCode = KeyCode.Escape;

function Update () {
if(Input.GetKeyDown(key))	Application.LoadLevel(0);
}