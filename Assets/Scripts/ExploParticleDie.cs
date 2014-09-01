using UnityEngine;
using System.Collections;

public class ExploParticleDie : MonoBehaviour {
	
	public float dieTime;
	// Update is called once per frame
	void Update () {
		dieTime = dieTime - Time.deltaTime;
		if(dieTime <= 0){
			Destroy(gameObject);
		}
	}
}
