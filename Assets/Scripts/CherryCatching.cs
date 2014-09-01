using UnityEngine;
using System.Collections;

public class CherryCatching : MonoBehaviour {
	
	public tk2dTextMesh score;
	public tk2dTextMesh scoreShade;
	public GameObject ExplosionParticle;
	public FlowControl flow;

	public AudioClip eatCherrySound;
	public AudioClip explosionSound;

	private DragonMover mover;
	private int scoreCount = 0;

	void Awake(){
		mover = transform.parent.GetComponent<DragonMover>();
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.name.Equals("Cherry(Clone)")){
			audio.PlayOneShot(eatCherrySound);
			increaseScore();
		} else if(col.gameObject.name.Equals("Bomb(Clone)")){
			bombCatch(true);
			Vector3	exploPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 4);
			GameObject explosion = (GameObject) Instantiate(ExplosionParticle, exploPosition, Quaternion.identity);
		} else if(col.gameObject.name.Equals("Fireball(Clone)")){
			bombCatch(true);
			Vector3	exploPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 4);
			GameObject explosion = (GameObject) Instantiate(ExplosionParticle, exploPosition, Quaternion.identity);
		} else if(col.gameObject.name.Equals("GoldenCherry(Clone)")){
			audio.PlayOneShot(eatCherrySound);
			increaseScore();
			increaseScore();
			increaseScore();
		}
		Destroy(col.gameObject);
		mover.eat();

	}

	void increaseScore(){

		scoreCount++;
		score.text = scoreCount.ToString();
		scoreShade.text = scoreCount.ToString();
		if(scoreCount % 10 == 0 && scoreCount > 0){
			flow.increaseSpeed();
		}
		if(scoreCount == 20){
			flow.startSunShooting();
		}
	}

	public void bombCatch(bool vibrate){
		if(!mover.isGameOver()){
			if(vibrate) Handheld.Vibrate();
			audio.PlayOneShot(explosionSound);
			flow.GameOver();
			mover.GameOver();
		}
	}

	void OnApplicationPause(bool pauseStatus){
		bombCatch(false);
	} 

	public void resetScore(){
		scoreCount = 0;
		score.text = scoreCount.ToString();
		scoreShade.text = scoreCount.ToString();
	}

	public int getScore(){
		return scoreCount;
	}

}
