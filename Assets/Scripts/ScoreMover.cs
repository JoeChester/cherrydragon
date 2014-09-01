using UnityEngine;
using System.Collections;

public class ScoreMover : MonoBehaviour {

	public tk2dTextMesh currentScoreText;
	public tk2dTextMesh currentScoreShade;
	public tk2dTextMesh highScoreText;
	public tk2dTextMesh highScoreShade;
	public GameObject newLabel; //only enable it if currentScore > highscore

	public float moveSpeed;
	
	private bool moveUp;
	private bool moveDown;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(moveUp){
			moveDown = false;
			transform.Translate(new Vector3(0,2,0) * moveSpeed * Time.deltaTime);
			if(transform.localPosition.y > 5){
				moveUp = false;
			}
		}
		
		if(moveDown){
			transform.Translate(new Vector3(0,-2,0) * moveSpeed * Time.deltaTime);
			if(transform.localPosition.y <= 1.4f){
				moveDown = false;
			}
		}

		//make shure not to overmove the ui element (caused by lags sometimes)
		if(transform.localPosition.x < 1.4f){
			transform.localPosition = new Vector3(transform.localPosition.x, 1.4f, transform.localPosition.z);
		}
		
	}
	
	public void moveOut(){
		moveUp = true;
	}
	
	public void moveIn(){
		moveDown = true;
	}

	public void setCurrentScore(int newScore){
		//First: get old Highscore from PlayerPreferences!
		int highscore = 0;
		try{
			highscore = PlayerPrefs.GetInt("highscore");
		} catch(PlayerPrefsException e) {
			highscore = 0;
		}

		if(newScore > highscore){
			highscore = newScore;
			newLabel.SetActive(true);
			try{
				PlayerPrefs.SetInt("highscore", newScore);
			} catch(PlayerPrefsException e) {
				Debug.Log(e.ToString());
			}
		} else {
			newLabel.SetActive(false);
		}

		currentScoreText.text = newScore.ToString();
		currentScoreShade.text = newScore.ToString();
		highScoreText.text = highscore.ToString();
		highScoreShade.text = highscore.ToString();

	}

}
