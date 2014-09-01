using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {


	public float moveSpeed;
	public TiltPhone tiltPhone; //move them out
	public TitleLogo titleLogo; //move them out
	public ScoreMover scoreMover; //move in and out
	public GameObject emitters; //enable them
	public GameObject score; //enable it
	public CherryCatching catching; //to reset Score

	public AudioClip onPressSound;
	
	private tk2dSpriteAnimator animator;
	private bool moveRight;
	private bool moveLeft;


	// Use this for initialization
	void Awake () {
		animator = GetComponent<tk2dSpriteAnimator>();
	}
	
	// Update is called once per frame
	void Update () {

		//Get Touch Input
		if(Input.touchCount > 0 ){
			Touch touch = Input.touches[0];
			Ray ray = Camera.mainCamera.ScreenPointToRay(touch.position);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
				StartPressed();
			} 
		}



		if(moveRight){
			moveLeft = false;
			transform.Translate(new Vector3(1,0,0) * moveSpeed * Time.deltaTime);
			if(transform.localPosition.x > 2.5){
				moveRight = false;
				animator.Play("StartButtonIdle");
			}
		}

		if(moveLeft){
			transform.Translate(new Vector3(-1,0,0) * moveSpeed * Time.deltaTime);
			if(transform.localPosition.x <= 0.35){
				moveLeft = false;
			}
		}

		//make shure not to overmove the ui element (caused by lags sometimes)
		if(transform.localPosition.x < 0.35f){
			transform.localPosition = new Vector3(0.35f, transform.localPosition.y, transform.localPosition.z);
		}

	}

	void OnMouseDown() {
		StartPressed();
	}


	public void StartPressed() {
		animator.Play ("StartButtonPress");
		audio.PlayOneShot(onPressSound);
		Debug.Log("START GAME!");
		moveRight = true;
		tiltPhone.moveOut();
		titleLogo.moveOut();
		scoreMover.moveOut();
		emitters.SetActive(true);
		score.SetActive(true);
		catching.resetScore();
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	public void GameOver(){
		emitters.SetActive(false);
		score.SetActive(false);
		GameObject[] destroyables = GameObject.FindGameObjectsWithTag("Respawn");
		foreach(GameObject g in destroyables){
			Destroy(g);
		}

		Debug.Log ("FINAL SCORE:" + catching.getScore().ToString());
		scoreMover.setCurrentScore(catching.getScore());
		scoreMover.moveIn();
		catching.resetScore();
		BackToMainMenu();

	}

	public void BackToMainMenu() {
		animator.Play("StartButtonIdle");
		moveLeft = true;
		tiltPhone.moveIn();
		//titleLogo.moveIn();
	}
}
