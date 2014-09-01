using UnityEngine;
using System.Collections;

public class TiltPhoneGraphic : MonoBehaviour {

	public Transform transform;

	private bool turnLeft = true;

	// Use this for initialization
	void Start () {
		turnLeft = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(turnLeft == true){
			transform.Rotate(new Vector3(0,0, 2) * Time.deltaTime * 50);
			if(transform.rotation.z > 0.45f){
				turnLeft = false;
			}
		
		} else {
			transform.Rotate(new Vector3(0,0, -2) * Time.deltaTime * 50);
			if(transform.rotation.z < -0.45f){
				turnLeft = true;
			}
		}
	
	}
}
