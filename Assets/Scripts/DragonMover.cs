using UnityEngine;
using System.Collections;

public class DragonMover : MonoBehaviour {

	public MovementOptions movement;
	// Require a character controller to be attached to the same game object
	private CharacterController controller;
	private tk2dSpriteAnimator animator;
	
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.

	public float EatingTime = 0.3f;

	public float gameovertime = 1;

	private float eatTime;

	private float lastDirection = 1;
	private bool isEating = false;
	
	private Vector3 offset = new Vector3(0,0,0);
	private Vector3 direction = new Vector3(0,0,0);

	private bool gameover = false;


	
	//Initialize position
	void Awake(){
		eatTime = EatingTime;
		controller = GetComponent<CharacterController>();
		animator = GetComponent<tk2dSpriteAnimator>();
		facingRight = true;
	}
	void FixedUpdate () {
		Vector3 fix = new Vector3(transform.position.x, 4.08f, -2);
		transform.position = fix;
	}
	
	// Update is called once per frame
	void Update () {
		if(!gameover){
		if(isEating && eatTime > 0){
			eatTime = eatTime - Time.deltaTime;
		} else {
			isEating = false;
		}

		transform.position.Set( transform.position.x, 4.08f , -2 );

		if(movement.enabled){
			//Get horizontal movement direction from axis & jump from Keyboard for dev
			movement.horizontalDirection = (float) Input.GetAxisRaw("Horizontal");	

			//Get accleration!
			if(movement.horizontalDirection == 0){
		    	if(Input.acceleration.x > 0.01f){
						movement.horizontalDirection = Input.acceleration.x /* Mathf.Sqrt(Mathf.Abs(Input.acceleration.x))*/ * 5 ;
					if(movement.horizontalDirection > 1)
						movement.horizontalDirection = 1;
				} else if(Input.acceleration.x < -0.03f){
						movement.horizontalDirection = Input.acceleration.x /* Mathf.Sqrt(Mathf.Abs(Input.acceleration.x))*/ * 5;
					if(movement.horizontalDirection < -1)
						movement.horizontalDirection = -1;
				}
			}


		} else {
			movement.horizontalDirection = 0;
		}
		if (movement.horizontalDirection != 0){
			direction.Set(movement.horizontalDirection, 0, 0);
			lastDirection = movement.horizontalDirection;
		} 
		MoveCharacter();

		//Count Down GameOver Time to re-enable the Dragon

		} else {
			gameovertime = gameovertime - Time.deltaTime;
			
			if(gameovertime <= 0){
				gameover = false;
				gameovertime = 1;
			}
		}
	}
	
	
	void MoveCharacter (){
		ApplyMovement();
		controller.Move(offset * Time.deltaTime);
		
	}
	
	void ApplyMovement (){
		if (movement.enabled) {
			offset.Set(movement.horizontalDirection * movement.walkSpeed, 0, 0); 
			ApplyWalkAnimation();
		} else {
			offset = Vector3.zero;
		}
	}
	
	//Apply Animations
	void ApplyWalkAnimation (){
		if(movement.horizontalDirection > 0){
			if(isEating){
				animator.Play ("eatRight");
			} else {
				animator.Play ("walkRight");
			}
		} else if(movement.horizontalDirection < 0){
			if(isEating){
				animator.Play ("eatLeft");
			} else {
				animator.Play ("walkLeft");
			}
		} else {
			ApplyStandAnimation();
		}
	}
	
	void ApplyStandAnimation (){
		if(lastDirection > 0){
			if(isEating){
				animator.Play ("eatRight");
			} else {
				animator.Play ("idleRight");
			}
		} else {
			if(isEating){
				animator.Play ("eatLeft");
			} else {
				animator.Play ("idleLeft");
			}
		}
	}

	public void eat(){
		isEating = true;
		eatTime = EatingTime;
	}

	public void GameOver(){
		gameover = true;
		if(lastDirection > 0){
			animator.Play ("koRight");
		} else {
			animator.Play ("koLeft");
		}
	}

	public bool isGameOver(){
		return this.gameover;
	}
	
}

[System.Serializable]
public class MovementOptions {
	/*******************************
* Public (Inspector) variables
*******************************/
	public bool enabled = true;	// Is the character controller enabled?
	public float walkSpeed;
	
	/*******************************
* NonSerialized variables
*******************************/
	
	// The character's current horizontal direction
	[System.NonSerialized]
	public float horizontalDirection;
	
	// The character's current direction (on all planes)
	[System.NonSerialized]
	public Vector3 direction;
	
	// The character's current movement offset
	[System.NonSerialized]
	public Vector3 offset;
	
}
