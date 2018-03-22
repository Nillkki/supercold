using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class GameManager : MonoBehaviour {

	public Transform player;

	public Vector3Int maxSpawnArea;
	public Vector3Int minSpawnArea;

	public GameObject targetPrefab;

	//TODO somekind of scoring system

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 90;
		InvokeRepeating ("SpawnTargetAtRandom", 1, 3);
	}

	//TODO dont let targets spawn on points where there is already a target or a tree etc.
	public void SpawnTargetAtRandom(){
		Vector3Int randomSpawn = new Vector3Int (Random.Range (minSpawnArea.x, maxSpawnArea.x), Random.Range (minSpawnArea.y, maxSpawnArea.y), Random.Range (minSpawnArea.z, maxSpawnArea.z));
		var target = LeanPool.Spawn (targetPrefab,
			randomSpawn,
			Quaternion.identity);
			
		//target.transform.LookAt (player);
		//target.transform.rotation = new Quaternion (0, target.transform.rotation.y, 0, 0);
	}


}
