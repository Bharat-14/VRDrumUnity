using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;
using System.Text;

public class AndroidDataReceiver : MonoBehaviour {

	public TextMesh textDisplay;
	public GameObject cubeLeft;
	public GameObject cubeRight;
	// Use this for initialization
	public float displayInterval = 1.0f;

	public DataFileController dataFileController;


	private float wearRollRight = float.NaN;
	private float wearPitchRight = float.NaN;
	private float wearAzimuthRight = float.NaN;
	private const double RADIANS_DEGREE = 180.0 / System.Math.PI;
	private Quaternion toRotationRight = Quaternion.identity;

	private float wearRollLeft = float.NaN;
	private float wearPitchLeft = float.NaN;
	private float wearAzimuthLeft = float.NaN;
	private Quaternion toRotationLeft = Quaternion.identity;

	private static float RadianToDegree(float angle){

		return (float)(angle * RADIANS_DEGREE); 
	}

	void Start () {
		StartCoroutine (ShowCoordinateRight());
		StartCoroutine (ShowCoordinateLeft());

		Input.compass.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

		cubeRight.transform.rotation = Quaternion.Slerp (cubeRight.transform.rotation, toRotationRight, Time.deltaTime * 5f);
		cubeLeft.transform.rotation = Quaternion.Slerp (cubeLeft.transform.rotation, toRotationLeft, Time.deltaTime * 5f);

//		print ("Delta Time : " + Time.deltaTime.ToString() + "     Delta Rotation [X:" + (cubeRight.transform.rotation.x - toRotationRight.x).ToString() + " Y:" + (cubeRight.transform.rotation.y - toRotationRight.y).ToString() +" Z:"+ (cubeRight.transform.rotation.z - toRotationRight.z).ToString() +"]");
//		print("Magnetometer reading: " + Input.compass.rawVector.ToString());
	}

	IEnumerator ShowCoordinateRight(){
		Transform cubeR = cubeRight.transform.GetChild (0);

		Vector3 positionBefore = cubeR.transform.position;
		yield return new WaitForSeconds(displayInterval);
		Vector3 positionAfter = cubeR.transform.position;


		Quaternion rot = Quaternion.Euler (52.8f, 0, 0);
		GameObject td = (GameObject)Instantiate(textDisplay.gameObject, cubeR.transform.position,rot );
//		textDisplay.text = cubeR.transform.position.ToString ();
		textDisplay.text =  cubeR.position.ToString();
		dataFileController.appendtoRightDataFile (cubeR.position.ToString ());

		print ("Distance Right: " + Vector3.Distance (positionAfter, positionBefore));
		StartCoroutine (ShowCoordinateRight());
//		print ("Show coordinate");
	}


	IEnumerator ShowCoordinateLeft(){
		Transform cubeL = cubeLeft.transform.GetChild (0);

		Vector3 positionBefore = cubeL.transform.position;
		yield return new WaitForSeconds(displayInterval);
		Vector3 positionAfter = cubeL.transform.position;

		Quaternion rot = Quaternion.Euler (52.8f, 0, 0);
		GameObject td = (GameObject)Instantiate(textDisplay.gameObject, cubeL.transform.position,rot );
		//		textDisplay.text = cubeR.transform.position.ToString ();
		textDisplay.text =  cubeL.position.ToString();
		dataFileController.appendtoLeftDataFile (cubeL.position.ToString ());
		print ("Distance Left: " + Vector3.Distance (positionAfter, positionBefore));

		StartCoroutine (ShowCoordinateLeft());
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
		Debug.Log ("RIGHT FLOATS : X " + x + " Y " + y + " Z " + z);

		wearAzimuthRight =  RadianToDegree (z);
//		Debug.Log ("wearAzimuth " + wearAzimuth);

		wearPitchRight =  RadianToDegree (y);
//		Debug.Log ("wearPitch " + wearPitch);

		wearRollRight = RadianToDegree (x);
//		Debug.Log ("wearRoll " + wearRoll);

		toRotationRight = Quaternion.Euler (wearPitchRight, wearRollRight, wearAzimuthRight);
		Debug.Log ("ToRotation" + toRotationRight);


	}
	void WearOrientationChangedleft(string value){
		//				Debug.Log ("SENSOR :" + value);
		string[] splitString = value.Split(new string[] {","}, System.StringSplitOptions.None);
		float x;
		float.TryParse (splitString [0], out x);
		float y;
		float.TryParse (splitString [1], out y);
		float z;
		float.TryParse (splitString [2], out z);

		//		Debug.Log ("SENSOR :" + value);
				Debug.Log ("LEFT FLOATS : X " + x + " Y " + y + " Z " + z);

		wearAzimuthLeft =  RadianToDegree (z);
//				Debug.Log ("wearAzimuth " + wearAzimuth);

		wearPitchLeft =  RadianToDegree (y);
//				Debug.Log ("wearPitch " + wearPitch);

		wearRollLeft = RadianToDegree (x);
//				Debug.Log ("wearRoll " + wearRoll);

		toRotationLeft = Quaternion.Euler (wearPitchLeft, wearRollLeft, wearAzimuthLeft);
//		Debug.Log ("ToRotation" + _toRotation);


	}
	//
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
