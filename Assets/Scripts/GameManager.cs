using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class GameManager : MonoBehaviour {

	public Transform player;

	public Vector3 maxSpawnArea;
	public Vector3 minSpawnArea;

	public GameObject targetPrefab;

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
		InvokeRepeating ("SpawnTargetAtRandom", 1, 3);
	}

	public void SpawnTargetAtRandom(){
		var target = LeanPool.Spawn (targetPrefab,
			new Vector3 (Random.Range (minSpawnArea.x, maxSpawnArea.x), Random.Range (minSpawnArea.y, maxSpawnArea.y), Random.Range (minSpawnArea.z, maxSpawnArea.z)),
			Quaternion.identity);
			
		target.transform.LookAt (player);
		target.transform.rotation = new Quaternion (0, target.transform.rotation.y, 0, 0);
	}


}
