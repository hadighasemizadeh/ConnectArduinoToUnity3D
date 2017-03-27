using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
public class Connect : MonoBehaviour {
	SerialPort streamPort = new SerialPort("COM7",9600);

	[HideInInspector] public bool  outLight = false;
	[HideInInspector] public bool  outBeep  = false;

	[HideInInspector] public int   outSpeed = 0;
	[HideInInspector] public float outMusic = 0;


	// Use this for initialization
	void Start () {
		streamPort.Open ();
	}
	
	// Update is called once per frame
	void Update () {
		string str = streamPort.ReadLine ();
		streamPort.BaseStream.Flush ();

		string[] command = str.Split (',');

		int temp0 = int.Parse (command [0]);
		outLight = (temp0 == 1)? true : false ;

		int temp1 = int.Parse (command [1]);
		outBeep = (temp1 == 1)? true : false ;

		outMusic  = float.Parse (command[2]);
		outSpeed  = int.Parse (command[3]);


//		print (str);
	}

}
