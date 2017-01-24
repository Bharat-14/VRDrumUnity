using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class DataFileController : MonoBehaviour {

//	string message;
//	string loadMessage = "Yeah working";
//	string data;
	FileInfo fLeft; 
	FileInfo fRight; 



//	private string fileName = "";

//	private string[] scores;

	void Awake(){
		fLeft = new FileInfo(Application.persistentDataPath + "\\" + "DataLeft.txt");
		fRight = new FileInfo(Application.persistentDataPath + "\\" + "DataRight.txt");


//		fileName = Application.persistentDataPath + "/settings.txt";
	}


	void Start()
	{
		StreamWriter wLeft;
		StreamWriter wRight;

		if(!fLeft.Exists && !fRight.Exists)
		{
			wLeft = fLeft.CreateText();  
			wRight = fRight.CreateText();    

		}
		else
		{
			fLeft.Delete();
			fRight.Delete();

			wLeft = fLeft.CreateText();
			wRight = fRight.CreateText();    

		}
		wLeft.WriteLine("Left Data");
		wLeft.Close();




		wRight.WriteLine("Right Data");
		wRight.Close();
	}

//	void OnGUI()
//	{
//		GUILayout.BeginArea(new Rect(0,0,500,500));
//		GUILayout.Label(message + " " + data);
//		if(GUILayout.Button("Save"))
//		{
//
//			if(!f.Exists)
//			{
//				message = "Creating File";
//				Save();
//			}
//			else
//			{
//				message = "Saving";
//				Save();
//			}
//		}
//		if(GUILayout.Button("Load"))
//		{
//			if(f.Exists)
//			{
//				Load();
//			}
//			else
//			{
//				message = "No File found";    
//			}
//		}
//		GUILayout.EndArea();
//	}

//	void Update(){
//		saveAppend ();
//	}
//
	public void appendtoLeftDataFile(string value)
	{
//		print ("Left : "+ value);

		if(fLeft.Exists)
		{
			StreamWriter w;
			w = fLeft.AppendText ();    
			w.WriteLine(value);
			w.Close();
		}

	}

	public void appendtoRightDataFile(string value)
	{
//		print ("Right : "+ value);

		if(fRight.Exists)
		{
			StreamWriter w;
			w = fRight.AppendText ();    
			w.WriteLine(value);
			w.Close();
		}

	}


//	void Load()
//	{
//		StreamReader r = File.OpenText(Application.dataPath + "\\" + "myFile.txt");
//		string info = r.ReadToEnd();
//		r.Close();
//		data = info;
//	}

}
