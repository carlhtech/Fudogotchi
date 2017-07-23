using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class onWaterClick : MonoBehaviour {

	public Button waterButton;

	public GameObject waterAnimation;
	public GameObject wateringCan;
	public GameObject waterHighlight;

	Animator canAnimation;
	Animator waterHighlightAnim;


	void Start()
	{
		canAnimation = wateringCan.GetComponent<Animator> ();
		waterHighlightAnim = waterHighlight.GetComponent<Animator> ();
		Button btn = waterButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		wateringCan.SetActive (false);
	}

	public void TaskOnClick()
	{
		if(GameObject.Find("Tomato").GetComponent<TomatoManager>().clickedTomato)
		{
			waterHighlight.SetActive (true);
			wateringCan.SetActive (true);
			canAnimation.Play ("CanPour");
			waterAnimation.SetActive (true);
			waterHighlightAnim.Play ("WaterHighlight");

			StartCoroutine (StopWater ());

			GameObject.Find ("Tomato").GetComponent<TomatoManager> ().updateThirst (1);
		} 
	}

	IEnumerator StopWater()
	{
		yield return new WaitForSeconds (2.0f);
		waterHighlight.SetActive (false);
		wateringCan.SetActive (false);
		waterAnimation.SetActive (false);
	}
}
