using UnityEngine;
using System.Collections;

public class TitleLogo : MonoBehaviour {

	public float moveSpeed;

	private bool moveUp;
	private bool moveDown;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(moveUp){
			transform.Translate(new Vector3(0,2,0) * moveSpeed * Time.deltaTime);
			if(transform.localPosition.y > 5){
				moveUp = false;
			}
		}

		if(moveDown){
			moveUp = false;
			transform.Translate(new Vector3(0,-2,0) * moveSpeed * Time.deltaTime);
			if(transform.localPosition.y <= 1.9f){
				moveDown = false;
			}
		}
	
		if(transform.localPosition.y < 1.9f){
			transform.localPosition = new Vector3(transform.localPosition.x, 1.9f , transform.localPosition.z);
		}

	}

	public void moveOut(){
		moveUp = true;
	}

	public void moveIn(){
		moveDown = true;
	}

}
