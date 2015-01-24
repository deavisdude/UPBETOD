#pragma strict

var delay : float = 1f;
var explosion : GameObject;

function Start () {
Invoke("Die", delay);
}

function Die () {
if(explosion != null)	Instantiate(explosion, transform.position, transform.rotation);
Destroy(gameObject);
}