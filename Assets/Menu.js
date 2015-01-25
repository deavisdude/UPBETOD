#pragma strict

function ChangeScene(scene: String) {
	Application.LoadLevel(scene);
}

function Exit(){
	if(Application.isEditor)	Debug.Break();
	else	Application.Quit();
}