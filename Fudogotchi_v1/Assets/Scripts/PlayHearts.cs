using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHearts : MonoBehaviour {

	public GameObject hearts;
	public GameObject highlight;

	Animator playHearts;
	Animator heartHighight;


	void Awake ()
	{
		playHearts = hearts.GetComponent<Animator>();
		heartHighight = highlight.GetComponent<Animator>();
	}

	void Start () {
		hearts.SetActive (false);
	}
	

	void Update () {
		if (Input.GetKey (KeyCode.C))
		{
			hearts.SetActive (true);
			highlight.SetActive (true);
			playHearts.Play ("HeartsAnimation");
			heartHighight.Play ("WaterHighlight");

		} else
		{
			highlight.SetActive (false);
			hearts.SetActive (false);

		}
	}
}
