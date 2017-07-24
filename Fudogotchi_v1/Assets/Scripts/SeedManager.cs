using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script for ading objects in random positions at random times

public class SeedManager : MonoBehaviour {

	public GameObject tomatoUI;
	Animator tomatoAnim;

	float x;
	float y;
	float z;

	Vector3 pos;

	public float maxTime = 10;
	public float minTime = 2;
	private float time;
	private float spawnTime;


	void Awake (){
		tomatoAnim = tomatoUI.GetComponent<Animator> ();
	}



	void Start () {
		
		SetRandomTime ();
		time = minTime;

	}


	void SpawnObject() {

		time = minTime;
		x = Random.Range (-100, 100);
		y = -1;
		z = Random.Range (-100, 100);
		pos = new Vector3 (x, y, z);
		transform.position = pos;

	}


	void FixedUpdate() {
		
		time += Time.deltaTime;
		if (time >= spawnTime)
		{
			SpawnObject ();
			SetRandomTime ();
		}
	}



	void SetRandomTime() {

		spawnTime = Random.Range (minTime, maxTime);
		
	}

	void Update(){
		if (Input.GetKey (KeyCode.A))
		{
			tomatoAnim.Play ("TomatoCapture");
		}
	}

}






