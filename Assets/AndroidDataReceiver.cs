using UnityEngine;
using System.Collections;

public class AndroidDataReceiver : MonoBehaviour {

	public TextMesh textDisplay;
//	public GameObject cubeLeft;
	public GameObject cubeRight;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void WearOrientationChanged(string value){
		Debug.Log ("SENSOR :" + value);
		//[string] valueArray = value.Split(",");
		string[] splitString = value.Split(new string[] {","}, System.StringSplitOptions.None);
		float x;
		float.TryParse (splitString [0], out x);
		float y;
		float.TryParse (splitString [1], out y);
		float z;
		float.TryParse (splitString [2], out z);
	
		//textDisplay.text = x.ToString ();
		//textDisplay.text = x.ToString ();
		//textDisplay.text = x.ToString ();
		Vector3 acc = new Vector3(x,y,z);

		cubeRight.transform.position =  Vector3.Lerp(cubeRight.transform.position, acc, Time.deltaTime );

		Vector3 forward = new Vector3 (acc.x, acc.y, acc.z);
		//cube.transform.rotation = Quaternion.LookRotation (forward);
		Quaternion q = new Quaternion(acc.x, acc.y, acc.z, 1.0f);

		cubeRight.transform.rotation = Quaternion.Lerp(cubeRight.transform.rotation, q	, Time.deltaTime);
	}

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
