using UnityEngine;
using System.Collections;

public class SphereHandler : MonoBehaviour {

	public float destroyInTime = 5.0f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyInTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
