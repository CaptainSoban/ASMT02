using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public Player a;
    private Text text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int m = a.score;
        this.GetComponent<Text>().text = "Total Score: " + m;

        if (a.life < 0) {
            GameObject.Find("Canvas/Note").GetComponent<Text>().text = "YOU DEAD!";
            Invoke("mmm", 2.0f);
        }
	}

    void mmm() {
        Application.LoadLevel("Scene");
    }
}
