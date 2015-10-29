/* Source File Name: Player.cs 
 * Author: Xiaoyu Wang 
 * Last Modified Date: Oct 23th 2015 
 * Description: Player movement control, Player phsics control, collision detection, note text reminder. 
 * Version: 2 
 *  
 * Class: player 
 * Method: OnCollisionStay2D, OnTriggerEnter2D, clear.
 * */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable] 
public class VelocityRange { 
	// PUBLIC INSTANCE VARIABLES 
 	public float vMin, vMax; 

 	// CONSTRUCTOR ++++++++++++++++++++++++++++++++ 
 	public VelocityRange(float vMin, float vMax) { 
 		this.vMin = vMin; 
 		this.vMax = vMax; 
 	} 
} 


public class Player : MonoBehaviour {
    public float speed = 1f, jump = 10f;
    public VelocityRange velocityRange = new VelocityRange(300f, 1000f);
    private Rigidbody2D _rigidbody2D; 
 	private Transform _transform; 
 	private Animator _animator; 

    private float _movingValue = 0; 
 	private bool _isFacingRight = true; 
 	private bool _isGrounded = true;

    public int life = 3;
    public int score = 0;
    public bool die = false;

    private Vector2 cp = new Vector2(0, -120);

    //public ene

	// Use this for initialization
	void Start () {
	    this._rigidbody2D = gameObject.GetComponent<Rigidbody2D> (); 
 		this._transform = gameObject.GetComponent<Transform> (); 
 		this._animator = gameObject.GetComponent<Animator> (); 

	}

    private Text text;
	// Update is called once per frame
	void FixedUpdate () {
	    float forceX = 0f; 
 		float forceY = 0f; 
 

 		float absVelX = Mathf.Abs (this._rigidbody2D.velocity.x); 
 		float absVelY = Mathf.Abs (this._rigidbody2D.velocity.y); 
 	 
 		this._movingValue = Input.GetAxis ("Horizontal"); // gives moving variable a value of -1 to 1 
 

 		if (this._movingValue != 0) { // player is moving 
 			//check if player is grounded 
 			if(this._isGrounded == true) {
                this._animator.SetInteger("AnimState", 1); 
 				if(this._movingValue > 0) { 
 					// move right 
 					if(absVelX < this.velocityRange.vMax) { 
 						forceX = this.speed; 
 						this._isFacingRight = true; 
 						this._flip(); 
 					} 
 				} else if (this._movingValue < 0) { 
 					// move left 
 					if(absVelX < this.velocityRange.vMax) { 
 						forceX = -this.speed; 
 						this._isFacingRight = false; 
 						this._flip (); 
 					} 
 				} 
 			} 
 		} else { 
 			// set our idle animation here 
 			this._animator.SetInteger("AnimState", 0); 
 		} 
 
 		// check if player is jumping 
 		if ((Input.GetKey ("up") || Input.GetKey (KeyCode.W))) { 
 			// chec if player is grounded 
 			if(this._isGrounded) { 
 				this._animator.SetInteger("AnimState", 2); 
 				if(absVelY < this.velocityRange.vMax) { 
 					forceY = this.jump;  
 					this._isGrounded = false; 
 				} 
 			} 
 		} 
 
 		// add force to the player to push him 
 		this._rigidbody2D.AddForce (new Vector2 (forceX, forceY));

        if (gameObject.GetComponent<Transform>().position.x < -360) {
            life = life - 1;

            gameObject.GetComponent<Transform>().position = cp;
            GameObject.Find("Canvas/Note").GetComponent<Text>().text = "OOPS!";
            Invoke("qwe", 2.0f);
        }

        if (gameObject.GetComponent<Transform>().position.x > 3480)
        {
            score = score + 10;

            gameObject.GetComponent<Transform>().position = cp;
            GameObject.Find("Canvas/Note").GetComponent<Text>().text = "GOOD!";
        }
	}

    void OnCollisionStay2D(Collision2D otherCollider) { 
 		if (otherCollider.gameObject.CompareTag ("Ground")) { 
 			this._isGrounded = true; 
 		} 
 	}

    void OnTriggerEnter2D(Collider2D other) {
        life--;
        gameObject.GetComponent<Transform>().position = cp;
        GameObject.Find("Canvas/Note").GetComponent<Text>().text = "OOPS!";
        Invoke("clear", 2.0f);
    }

    private void _flip() { 
 		if (this._isFacingRight) { 
 			this._transform.localScale = new Vector3(1f, 1f, 1f); // reset to normal scale 
 		} else { 
 			this._transform.localScale = new Vector3(-1f, 1f, 1f); 
 		} 
 	}


    void clear() {
        GameObject.Find("Canvas/Note").GetComponent<Text>().text = " ";
    }
}
