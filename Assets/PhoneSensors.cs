using UnityEngine;
using System.Collections;

public class PhoneSensors : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("Chicken Nuggets!!!");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PhoneOrientationChanged(string message) {

		Debug.Log (message);
	}
}
