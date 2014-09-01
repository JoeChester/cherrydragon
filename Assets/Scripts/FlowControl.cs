using UnityEngine;
using System.Collections;

public class FlowControl : MonoBehaviour {

	public EmitCherries[] emitters;

	public EmitFireballs sun; //enable this on 20 points;


	//This Script controls the Game Over Screen, Highscore, Ranking, maybe Google Play


	public StartButton startButton;
	

	public void GameOver(){
		//scoreMover.moveOut();
		startButton.GameOver();
		this.resetSpeed();
		this.stopSunShooting();
	}

	public void increaseSpeed(){
		foreach(EmitCherries emit in emitters){
			emit.increaseSpeed();
		}
	}

	public void resetSpeed(){
		foreach(EmitCherries emit in emitters){
			emit.resetSpeed();
		}
	}

	public void startSunShooting(){
		sun.setShoot(true);
	}

	public void stopSunShooting(){
		sun.setShoot(false);
	}

}
