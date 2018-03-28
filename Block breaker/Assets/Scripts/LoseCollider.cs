using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	StartEvent levelManager;

	void Start(){
		levelManager = GameObject.FindObjectOfType<StartEvent> ();
	}
	void OnTriggerEnter2D(Collider2D trigger){
		print ("Trigger event");
		levelManager.StartLevel ("Lose");
	}
	void OnCollisionEnter2D(Collision2D collision){
		print ("Collision event");

	}
}
