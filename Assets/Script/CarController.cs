using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
	
	public Light[] carLights;

	public AudioSource beep;
	private AudioSource music;

	private bool sounfToggle = false;
	private bool lightToggle = false;

	private Connect con;
	private Rigidbody rb;

	public float power = 2;

	// Use this for initialization
	void Start () {
		con   = GetComponent<Connect> ();
		rb    = GetComponent<Rigidbody> ();
		music = GetComponent<AudioSource> ();
		music.volume = con.outMusic;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		rb.velocity = con.outSpeed*power*Time.fixedDeltaTime*Vector3.forward;
	}

	void Update(){

		if (con.outBeep)
			beep.Play ();

		if(con.outLight){
			lightToggle = !lightToggle;
		}

		ChangeCarLight (lightToggle);

		music.volume = con.outMusic;
	}

	private void ChangeCarLight(bool state){
		
		foreach (var carLight in carLights) {
			carLight.enabled = state;
		}
	}
}
