using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
		
		public GameObject[] GibbyExplosion;
		
		public int ExplosionType = 1; //Types of explosions
		void Update()
	{
		/*if(ExplosionType == 1)
		{
			foreach(GameObject gibs in GibbyExplosion)
			{
				GameObject gibInstance = Instantiate(gib,transform.position + Random.insideUnitSphere*spawnRadius,transform.rotation) as GameObject;
				gibInstance.rigidbody.AddExplosionForce(explosionForce,transform.position,spawnRadius);
			}
		}
		
		if(ExplosionType == 2)
		{
			
			//More Explosiony Stuff
		}
		
		//if(ExplosionType == 3) etc....
	*/}
}
