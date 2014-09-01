using UnityEngine;
using System.Collections;

public class EmitCherries : MonoBehaviour {

	public GameObject cherry;
	public GameObject bomb;
	public GameObject goldenCherry;
	public float dieTime;
	public float speedMin;
	public float speedMax;
	public float initSpeedMin;
	public float initSpeedMax; //Double these values to keep reference
	public float bombChance;
	public float initBombChance;
	public float goldenCherryChance;

	public float createSpeedMax;

	private float nextEmit;


	// Use this for initialization
	void Start () {
		nextEmit = Random.Range(speedMin, speedMax);
	}

	// Update is called once per frame
	void Update () {
		nextEmit = nextEmit - Time.deltaTime;

		if(nextEmit <= 0){

			Vector3 randomVecY = new Vector3(0, -0.00001f * Random.Range(0,createSpeedMax), 0);
			float decider = Random.Range(0, bombChance);
			if(decider > 0.5f){ //emit a bomb
				GameObject newBomb = (GameObject) Instantiate(bomb, this.transform.position, Quaternion.identity);
				newBomb.rigidbody.AddForce(randomVecY);
			} else { //emit a cherry. decide whether the cherry is golden with some low chance
				float deciderGold = Random.Range(0,1f);
				GameObject newCherry;
				if(deciderGold < goldenCherryChance){
					newCherry = (GameObject) Instantiate(goldenCherry, this.transform.position, Quaternion.identity);
				} else {
					newCherry = (GameObject) Instantiate(cherry, this.transform.position, Quaternion.identity);
				}
				newCherry.rigidbody.AddForce(randomVecY);
			}
			nextEmit = Random.Range(speedMin, speedMax);
		}
	
	}

	public void resetSpeed(){
		speedMin = initSpeedMin;
		speedMax = initSpeedMax;
		bombChance = initBombChance;
	}

	public void increaseSpeed(){
		if(speedMin > 0.4f){
		speedMin = (float) speedMin - (speedMin * 0.2f);
		speedMax = (float) speedMax - (speedMax * 0.2f);
		} else if(this.bombChance < 5f){
			this.bombChance = bombChance * 2;
		}
	}

}
