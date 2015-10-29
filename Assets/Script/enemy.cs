/* Source File Name: enemy.cs 
 * Author: Xiaoyu Wang 
 * Last Modified Date: Oct 23th 2015 
 * Description: Make the enemies move. 
 * Version: 2 
 *  
 * Class: enemy 
 * Method: 
 * */
using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

    private Vector2 newPosition = new Vector2(0.0f, 0.0f);
    private Vector2 cp = new Vector2(0.0f, -210);
    public Player thIn;

	// Use this for initialization
	void Start () {
        newPosition.y = 0;
	}
	
	// Update is called once per frame
	void Update () {
        newPosition.x = 1 - thIn.score - 2;

        cp = gameObject.GetComponent<Transform>().position;
        gameObject.GetComponent<Transform>().position = cp + this.newPosition;
        cp = gameObject.GetComponent<Transform>().position;
	}
}
