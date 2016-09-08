using UnityEngine;
using System.Collections;

public class AndroidDataReceiver : MonoBehaviour {

	public TextMesh textDisplay;
//	public GameObject cubeLeft;
	public GameObject cubeRight;
	// Use this for initialization


	public float wearRoll = float.NaN;
	private float wearPitch = float.NaN;
	private float wearAzimuth = float.NaN;

	private const double RADIANS_DEGREE = 180.0 / System.Math.PI;
	private Quaternion _toRotation = Quaternion.identity;

	private static float RadianToDegree(float angle){

		return (float)(angle * RADIANS_DEGREE); 
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log ("ToRotation" + _toRotation);

//		transform.rotation = Quaternion.Lerp (transform.rotation, _toRotation, Time.deltaTime * 10);
		cubeRight.transform.rotation = Quaternion.Lerp (cubeRight.transform.rotation, _toRotation, Time.deltaTime * 10f);

	}




	void WearOrientationChanged(string value){
//				Debug.Log ("SENSOR :" + value);
				string[] splitString = value.Split(new string[] {","}, System.StringSplitOptions.None);
				float x;
				float.TryParse (splitString [0], out x);
				float y;
				float.TryParse (splitString [1], out y);
				float z;
				float.TryParse (splitString [2], out z);
			
//		Debug.Log ("SENSOR :" + value);
//		Debug.Log ("FLOATS : X" + x + " Y " + y + " Z " + z);

		wearAzimuth =  RadianToDegree (z);
//		Debug.Log ("wearAzimuth " + wearAzimuth);

		wearPitch =  RadianToDegree (y);
//		Debug.Log ("wearPitch " + wearPitch);

		wearRoll = RadianToDegree (x);
//		Debug.Log ("wearRoll " + wearRoll);

		_toRotation = Quaternion.Euler (wearPitch, wearRoll, wearAzimuth);
		Debug.Log ("ToRotation" + _toRotation);


	}
//
//	void WearOrientationChanged(string value){
//		Debug.Log ("SENSOR :" + value);
//		//[string] valueArray = value.Split(",");
//		string[] splitString = value.Split(new string[] {","}, System.StringSplitOptions.None);
//		float x;
//		float.TryParse (splitString [0], out x);
//		float y;
//		float.TryParse (splitString [1], out y);
//		float z;
//		float.TryParse (splitString [2], out z);
//	
//		//textDisplay.text = x.ToString ();
//		//textDisplay.text = x.ToString ();
//		//textDisplay.text = x.ToString ();
//		Vector3 acc = new Vector3(x,y,z);
//
////		cubeRight.transform.position =  Vector3.Lerp(cubeRight.transform.position, acc, Time.deltaTime );
//		Vector3 forward = new Vector3 (acc.x, acc.y, acc.z);
//		//cube.transform.rotation = Quaternion.LookRotation (forward);
//		cubeRight.GetComponent<Rigidbody>().AddRelativeForce(acc,ForceMode.Acceleration);
//			
////		Quaternion q = new Quaternion(acc.x, acc.y, acc.z, 1.0f);
//
////		cubeRight.transform.rotation = Quaternion.Lerp(cubeRight.transform.rotation, q	, Time.deltaTime);
//
//
//	}

//	void WearOrientationChangedLeft(string value){
//		Debug.Log ("SENSOR :" + value);
//		//[string] valueArray = value.Split(",");
//		string[] splitString = value.Split(new string[] {","}, System.StringSplitOptions.None);
//		float x;
//		float.TryParse (splitString [0], out x);
//		float y;
//		float.TryParse (splitString [1], out y);
//		float z;
//		float.TryParse (splitString [2], out z);
//
//		//textDisplay.text = x.ToString ();
//		//textDisplay.text = x.ToString ();
//		//textDisplay.text = x.ToString ();
//		Vector3 acc = new Vector3(x,y,z);
//
//		cubeLeft.transform.position =  Vector3.Lerp(cubeLeft.transform.position, acc, Time.deltaTime );
//
//		Vector3 forward = new Vector3 (acc.x, acc.y, acc.z);
//		//cube.transform.rotation = Quaternion.LookRotation (forward);
//		Quaternion q = new Quaternion(acc.x, acc.y, acc.z, 1.0f);
//
//		cubeLeft.transform.rotation = Quaternion.Lerp(cubeLeft.transform.rotation, q	, Time.deltaTime);
//	}
		
}
