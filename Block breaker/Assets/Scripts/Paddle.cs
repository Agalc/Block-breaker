using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay;
	public float minX = 1.18f,maxX= 14.8f;
	private Ball ball;
	float mouseInBlocks;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A))
			autoPlay = !autoPlay;
		if (!autoPlay) {
			PlayWithMouse ();
		} else {
			AutoPlay();
		}
	}
	void AutoPlay(){
		Vector3 paddlePos = new Vector3(8f,this.transform.position.y,0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
	}

	void PlayWithMouse(){
		Vector3 paddlePos = new Vector3(8f,this.transform.position.y,0f);
		mouseInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp (mouseInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}
}
