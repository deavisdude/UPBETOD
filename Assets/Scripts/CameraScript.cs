using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public int numPlayers;
	public Transform[] players;
	int farthestDist = 10;
	// Update is called once per frame
	void Start()
	{
		players = new Transform[numPlayers];
	}
	void Update () 
	{
		for (int i = 0; i<numPlayers; i++) {
			for(int i2 = 0;i < numPlayers;i2++)
			{
				if((Mathf.Abs (transform.position.x)-Mathf.Abs(players[i].position.x)) > farthestDist)
				{
					farthestDist = (Mathf.Abs (Mathf.CeilToInt(transform.position.x))-Mathf.Abs(Mathf.CeilToInt(players[i2].position.x)));
				}
			}
		
		}
		if(farthestDist > 10)
		Camera.main.orthographicSize = farthestDist;
		else
		Camera.main.orthographicSize = 10f;
	}

}
