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
	const int maxAmmo = 12;
	public int ammo = maxAmmo;
	public bool isShooting;
	
	// Update is called once per frame
	void Update () {
		
		UpdateGunPos ();

		if (GvrControllerInput.TouchDown || Input.GetButtonDown("Fire1")) {
			if (!isShooting) {
				if (ammo > 0) {
					Shoot ();
				} else {
					Reload ();
				}
			}
		}

	}

	void UpdateGunPos(){
		arm.rotation = GvrControllerInput.Orientation;
	}

	void UpdateAudio(){
		//randomize for a little variation in sound
		myAs.pitch = Random.Range (0.9f, 1.1f);
		myAs.volume = Random.Range (0.9f, 1f);
	}

	void Shoot(){
		gunAC.SetTrigger ("Shoot");
		gunPS.Play ();
		shellPS.Play ();
		UpdateAudio ();
		myAs.PlayOneShot (shootSound);
		ammo--;
		FireRay ();
	}

	void FireRay(){
		Ray ray = new Ray(barrelEnd.position, barrelEnd.TransformDirection(Vector3.forward));
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 100)){
			if (hit.collider.tag == "Target") {
				hit.rigidbody.AddForceAtPosition (ray.direction * 100, hit.point);
			}
		}
	}

	void Reload(){
		ammo = maxAmmo;
	}
}
