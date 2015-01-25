using UnityEngine;
using System.Collections;

public class SpawnPowerUps : MonoBehaviour {
	
	public GameObject[] spawnObject;
	
	public Transform parent;
	
	//Range of Powerups
	public float xRange = 1.0f;
	public float yRange = .1f;
	public int currentspawn,maxspawn;
	//setting the time for the spawn times
	public float minSpawnTime = 10.0f;
	public float maxSpawnTime = 20.0f;
	
	void Start()
	{
		maxspawn = 1;
		//Startup for the spawning
		Invoke("SpawnUp", Random.Range(minSpawnTime,maxSpawnTime));
	}
	
	void SpawnUp() //Recursive Bitches!
	{

			if(currentspawn < maxspawn)
			{
				int spawnObjectIndex = Random.Range(0,spawnObject.Length);
				GameObject instance = Instantiate(spawnObject[spawnObjectIndex],transform.position, spawnObject[spawnObjectIndex].transform.rotation) as GameObject;
				instance.transform.parent = transform;
			currentspawn ++;
				Invoke("SpawnUp", Random.Range(minSpawnTime,maxSpawnTime));
			}

		else{Invoke("SpawnUp", Random.Range(minSpawnTime,maxSpawnTime));
		}
	}
}