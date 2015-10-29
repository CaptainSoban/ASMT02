/* Source File Name: Life.cs 
 * Author: Xiaoyu Wang 
 * Last Modified Date: Oct 23th 2015 
 * Description: Count and display life. 
 * Version: 2 
 *  
 * Class: Life 
 * Method:
 * */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Life : MonoBehaviour {

    public Player a;
    private Text text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int m = a.life;
        this.GetComponent<Text>().text = ("Lives Remain: " + m);
	}
}
