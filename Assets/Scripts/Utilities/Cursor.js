#pragma strict

function Start(){
Screen.showCursor = false;
}

function Update () {
transform.position = Vector3(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height, 0);
}