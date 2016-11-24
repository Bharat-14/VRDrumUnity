using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
//	 AudioSource audio1;
//	AudioSource audio2;
//	AudioSource audio3;
//	AudioSource audio4;
//	public AudioClip clip;
	public Rigidbody rb;
	// Use this for initialization

	public  Vector3 previous;
	public  float velocity;
	public  float velocityY;

	void Start () {
		
	}


//		void OnCollisionEnter(Collision collision) {
//		print ("Test");
//
//		if (collision.relativeVelocity.magnitude > 2)
////			audio.Play();
//			coll.GetComponent<AudioSource> ().Play ();
//		
//
//	}

	void Update(){
		velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
		velocityY = ((transform.position.y - previous.y)) / Time.deltaTime;

		previous = transform.position;

	}
//

	void OnTriggerEnter(Collider other) {
		
		print ("VelocityY " + velocityY );
//		print ("Other Velocity" + other.GetComponent<Rigidbody>().velocity+ "   "+ other.GetComponent<Rigidbody>().angularVelocity  );

		AudioSource adSource = other.GetComponent<AudioSource> ();
		adSource.volume = velocity / 35f;
		adSource.Play ();



	}
}
