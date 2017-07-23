using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayWater : MonoBehaviour {


	public GameObject tomatoObject;
	public GameObject waterAnimation;
	public GameObject wateringCan;
	public GameObject waterHighlight;



	Animator canAnimation;
	Animator waterHighlightAnim;


	void Awake (){
		canAnimation = wateringCan.GetComponent<Animator> ();
		waterHighlightAnim = waterHighlight.GetComponent<Animator> ();
	}


	void Start () {
		waterAnimation.SetActive (false);

	}


	void Update () {
		if (Input.GetKey (KeyCode.A))
		{
			waterHighlight.SetActive (true);
			wateringCan.SetActive (true);
			canAnimation.Play ("CanPour");
			waterAnimation.SetActive (true);
			waterHighlightAnim.Play ("WaterHighlight");
		} 

		else 
		{
			wateringCan.SetActive (false);
			waterHighlight.SetActive (false);
		}
	}




}
