using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	//
	public AudioClip expl;
	public static int breakableCount = 0;
	public GameObject smoke;
	public Sprite[] hitSprites;
	//
	int timesHit;
	StartEvent levelMaganer;
	bool isBreakable;

	// Use this for initialization
	void Start ()
	{
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
		levelMaganer = FindObjectOfType<StartEvent> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		AudioSource.PlayClipAtPoint (expl, transform.position);
		if (isBreakable)
			HandleHits ();
	}

	void HandleHits ()
	{
		int maxHits = hitSprites.Length + 1;
		timesHit++;
		if (timesHit >= maxHits) {
			breakableCount--;
			SmokePuff();
			Destroy (gameObject);
			levelMaganer.brickDestroyed ();
		} else
			LoadSprites ();
	}
	void SmokePuff(){
		GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer> ().color;
	}

	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex] != null)
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		else
			Debug.LogError ("Sprite is missing");
	}
}
