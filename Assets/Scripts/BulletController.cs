using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	private Transform bullet;
	public float speed;
	public AudioClip destroyEnemy;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		bullet = GetComponent<Transform> ();
		audioSource = GetComponent<AudioSource>();
	
	}

	void FixedUpdate(){
		bullet.position += Vector3.up * speed;

		if (bullet.position.y >= 10)
			Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			Destroy (other.gameObject);
			Destroy (gameObject);
			audioSource.clip = destroyEnemy;
			audioSource.Play();
			PlayerScore	.playerScore += 10;
							
		} else if (other.tag == "Base")
			Destroy (gameObject);
	}

}
