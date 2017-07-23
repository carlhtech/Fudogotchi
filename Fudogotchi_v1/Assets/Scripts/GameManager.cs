using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {



	public GameObject thirstText;
	public GameObject tomato;



	
	// Update is called once per frame
	void Update () {
		thirstText.GetComponent<Text> ().text = "" + tomato.GetComponent<TomatoManager> ().thirst;
	}
}
