using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	Paddle paddle;

	bool isStarted = false;
	Vector3 fromPaddleToBall;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		fromPaddleToBall = this.transform.position - paddle.transform.position;
	}
	void OnCollisionEnter2D(Collision2D collision){
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
		if (isStarted) {
			audio.Play ();
			rigidbody2D.velocity += tweak;
		}
	}
	// Update is called once per frame
	void Update () {
		if (!isStarted) {
			//if(Input.GetKeyDown(KeyCode.F)) this.rigidbody2D.velocity += new Vector2(1f,10f);
			//if(Input.GetKeyDown(KeyCode.S)) this.rigidbody2D.velocity -= new Vector2(1f,10f);
			this.transform.position = paddle.transform.position + fromPaddleToBall;
			if (Input.GetMouseButtonDown(0)){
				this.rigidbody2D.velocity = new Vector2 (1f,10f);
				isStarted = true;
			}
		}
	}
}
