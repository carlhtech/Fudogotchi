using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinScene : MonoBehaviour {


	public GameObject hearts;
	public GameObject wateringCan;

	Animator playHearts;
	Animator playWateringCan;
	Animator pumpkinGrow;


	void Awake (){
		playHearts = hearts.GetComponent<Animator> ();
		playWateringCan = wateringCan.GetComponent<Animator> ();
		pumpkinGrow = GetComponent<Animator> ();

	}


	void Start () {
		//hearts.SetActive (false);
		//wateringCan.SetActive (false);

	}
	
	void Update () {
		if (Input.GetKey (KeyCode.P))
		{
			hearts.SetActive (true);
			wateringCan.SetActive (true);

			pumpkinGrow.Play ("PumpkinGrowAnim");
			playHearts.Play ("HeartsAnimation");
			playWateringCan.Play ("CanPour");

		} else
		{
			hearts.SetActive (false);
			wateringCan.SetActive (false);
		}
	}
}
