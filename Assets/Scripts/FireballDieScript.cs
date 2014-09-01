using UnityEngine;
using System.Collections;

public class FireballDieScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y <= 2.5){
			Destroy(gameObject);
		}
	}
}
