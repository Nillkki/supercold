using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class Target : MonoBehaviour {

	public GameManager gm;

	public AudioSource myAs;
	public AudioClip hitSound;

	private Renderer rend;
	public Color liveColor;
	public Color deadColor;

	void OnEnable(){
		if (!gm) gm = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager>();
		if (!rend) rend = GetComponent<Renderer>();
		ChangeColor (liveColor);
	}

	void ChangeColor(Color c){
		rend.material.SetColor ("_Color", c);
	}

	public void GetHit(){
		myAs.PlayOneShot (hitSound);
		ChangeColor (deadColor);
		LeanPool.Despawn (transform.parent, 1f);
	}
}
