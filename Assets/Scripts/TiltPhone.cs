using UnityEngine;
using System.Collections;

public class TiltPhone : MonoBehaviour {


	public float moveSpeed;

	private bool moveLeft;
	private bool moveRight;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(moveLeft){
			moveRight = false;
			transform.Translate(new Vector3(-1,0,0) * moveSpeed * Time.deltaTime);
			if(transform.localPosition.x < -5){
				moveLeft = false;
			}
		}

		if(moveRight){
			transform.Translate(new Vector3(1,0,0) * moveSpeed * Time.deltaTime);
			if(transform.localPosition.x >= -1.85f){
				moveRight = false;
			}
		}

		//make shure not to overmove the ui element (caused by lags sometimes)
		if(transform.localPosition.x > -1.85f){
			transform.localPosition = new Vector3(-1.85f, transform.localPosition.y, transform.localPosition.z);
		}

	}

	public void moveOut(){
		moveLeft = true;
	}
	public void moveIn(){
		moveRight = true;
	}
}
