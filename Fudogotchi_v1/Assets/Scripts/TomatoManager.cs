using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TomatoManager : MonoBehaviour {

	[SerializeField]
	private int _thirst;
	private bool serverTime;
	public bool clickedTomato = false;

	public GameObject tomatoHighlight;



	void Start () {
		PlayerPrefs.SetString ("then", "07/19/2017 11:20:12");
		updateStatus ();
	}

	//Will detect when the game object has been clicked on and make it 'clicked on = true'... only tomato at the moment
	void FixedUpdate(){
		if (Input.GetMouseButtonDown (0))
		{
			if (!clickedTomato)
			{
				RaycastHit hitInfo = new RaycastHit ();
				bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo);
				if (hitInfo.transform.gameObject.tag == "Tomato")
				{
					clickedTomato = true;
					Debug.Log ("clicked the tomato");
					tomatoHighlight.SetActive (true);
					//StartCoroutine (flash ());
				}
			} else
			{
				RaycastHit hitInfo = new RaycastHit ();
				bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo);
				if (hitInfo.transform.gameObject.tag == "Tomato")
				{
					clickedTomato = false;
					Debug.Log ("unclicked the tomato");
					tomatoHighlight.SetActive (false);
				}
			}



		}
	}


	// player prefs saves thirst as 100 then we are getting time and subtracting hours * 2 until 0 is reached
	void updateStatus(){

		if (!PlayerPrefs.HasKey ("_thirst"))
		{
			_thirst = 100;
			PlayerPrefs.SetInt ("_thirst", _thirst);
		} else
		{
			_thirst = PlayerPrefs.GetInt ("_thirst");
		}

		if (!PlayerPrefs.HasKey ("then"))
			PlayerPrefs.SetString ("then", getStringTime ());

		TimeSpan ts = getTimeSpan ();

		_thirst -= (int)(ts.TotalHours * 10);
		if (_thirst < 0)
			_thirst = 0;

		//Debug.Log (getTimeSpan ().ToString ());
		//Debug.Log (getTimeSpan ().TotalHours);

		if (serverTime)
			updateDevice ();
		else
			InvokeRepeating ("updateDevice", 0f, 30f);

	}
	

	void updateDevice(){
		PlayerPrefs.SetString ("then", getStringTime ());
	}


	TimeSpan getTimeSpan(){
		if (serverTime)
			return new TimeSpan ();
		else
			return DateTime.Now - Convert.ToDateTime (PlayerPrefs.GetString ("then"));
	}


	string getStringTime(){
		DateTime now = DateTime.Now;
		return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
	}


	public int thirst{
		get{return _thirst;}
		set{ _thirst = value; }
	}


	public void updateThirst(int i){
		thirst += i;
		if (thirst > 100)
			thirst = 100;
	}

	/*IEnumerator flash(){
		while(clickedTomato == true)
		{
			tomatoHighlight.SetActive  (false);
			yield return new WaitForSeconds (0.5f);
			tomatoHighlight.SetActive (true);
			yield return new WaitForSeconds (0.5f);
		}
	}*/

}
