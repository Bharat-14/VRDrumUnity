using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
//	 AudioSource audio1;
//	AudioSource audio2;
//	AudioSource audio3;
//	AudioSource audio4;
//	public AudioClip clip;
	// Use this for initialization
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
//

	void OnTriggerEnter(Collider other) {
		print ("Test Trigger" + other);
		other.GetComponent<AudioSource> ().Play ();



	}
}
