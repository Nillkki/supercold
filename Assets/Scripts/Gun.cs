using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleVR;

public class Gun : MonoBehaviour {
	
	//parts etc
	public Transform arm;
	public Transform barrelEnd;
	public Animator gunAC;
	public ParticleSystem gunPS;
	public ParticleSystem shellPS;

	//sounds
	public AudioSource myAs;
	public AudioClip shootSound;

	//vars
	public bool isShooting;
	
	// Update is called once per frame
	void Update () {
		
		UpdateGunPos ();

		if (GvrControllerInput.TouchDown || Input.GetButtonDown("Fire1")) {
			if (!isShooting) {
					Shoot ();
			}
		}
	}

	void UpdateGunPos(){
		arm.rotation = GvrControllerInput.Orientation;
	}

	void UpdateAudio(){
		myAs.pitch = Random.Range (0.9f, 1.1f);
		myAs.volume = Random.Range (0.5f, 0.6f);
	}

	//TODO, rekyyli?
	void Shoot(){
		gunAC.SetTrigger ("Shoot"); 
		gunPS.Play ();
		shellPS.Play ();
		UpdateAudio ();
		myAs.PlayOneShot (shootSound);
		FireRay ();
	}

	void FireRay(){
		Ray ray = new Ray(barrelEnd.position, barrelEnd.TransformDirection(Vector3.forward));
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 32)) {
			if (hit.collider.tag == "Target") {
				hit.rigidbody.AddForceAtPosition (ray.direction * 250, hit.point);
				hit.transform.GetComponent<Target> ().GetHit ();

			}
		}
	}

}
