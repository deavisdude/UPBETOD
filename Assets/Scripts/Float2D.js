#pragma strict

var startPosition : Vector3;
var random : float;

function Start () {
startPosition = transform.position;
random = Random.value;
}

function Update () {
transform.position = startPosition + Vector2(Mathf.Sin(Time.time + random * 90), Mathf.Cos(Time.time + random) * Mathf.Sin(random - 0.5f)) * 0.02f * transform.localScale.magnitude;
}