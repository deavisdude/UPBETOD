using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelTransition : MonoBehaviour {

    public Transform target;
    public float speed;
    public bool clicked = false;

	public void Click(){
        clicked = true;
    }
	// Update is called once per frame
	void Update () {
        if(clicked){
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        }
}
