using UnityEngine;
using System.Collections;

public class EmitFireballs : MonoBehaviour {

	public GameObject fireball;
	public GameObject dragon;
	public SunMouth sunMouth;
	public float dieTime;
	public float chanceMin;
	public float chanceMax;

	public bool shoot;

	private float createSpeed;
	private float nextEmit;
	private float scale = 0.000005f;

	private float initChanceMin;
	private float initChanceMax;


	// Use this for initialization
	void Start () {
		nextEmit = Random.Range(chanceMin, chanceMax);
		initChanceMin = chanceMin;
		initChanceMax = chanceMax;
	}
	
	// Update is called once per frame
	void Update () {
		if(shoot){
		nextEmit = nextEmit - Time.deltaTime;

		//Emit a Fireball and Add a Force to the dragons direction to it
		if(nextEmit <= 0){
				Vector3 fireballPosition = new Vector3(this.transform.position.x, this.transform.position.y, -8);
			GameObject newFireball = (GameObject) Instantiate(fireball, fireballPosition, Quaternion.identity);
			//Calculate the vector between the dragon and the fireball to throw it at the dragon
			//direction = dragonVec - EmitVec
			Vector3 fireballDirection = new Vector3();
			fireballDirection = dragon.transform.position - transform.position;
			fireballDirection = new Vector3(scale * fireballDirection.x, scale * fireballDirection.y, 0);
			newFireball.rigidbody.AddForce(fireballDirection);
			
			sunMouth.showMouthAnimation();

			nextEmit = Random.Range(chanceMin, chanceMax);

		}
		}
	}

	public void setShoot(bool b){
		shoot = b;
	}

	public void resetSpeed(){
		chanceMin = initChanceMin;
		chanceMax = initChanceMax;
	}

	public void increaseSpeed(){
		chanceMin = chanceMin - (chanceMin * 0.1f);
		chanceMax = chanceMax - (chanceMax * 0.1f);
	}


}
