using UnityEngine;
using System.Collections;

public class SunMouth : MonoBehaviour {

	public float dieTime; 
	private bool show;
	private float tempDieTime;

	// Use this for initialization
	void Start () {
		tempDieTime = dieTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(show){
			tempDieTime = tempDieTime - Time.deltaTime;
			if(tempDieTime <= 0){
				renderer.enabled = false;
				show = false;
				tempDieTime = dieTime;
			}
		}
	}

	public void showMouthAnimation(){
		show = true;
		renderer.enabled = true;
	}
}
