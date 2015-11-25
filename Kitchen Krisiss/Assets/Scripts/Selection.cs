using UnityEngine;
using System.Collections;

public class Selection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Select1")) {
			GameObject thePlayer = GameObject.Find("Pea");
			Pea playerScript = thePlayer.GetComponent<Pea>();
			playerScript.selected = false;
			playerScript.jump = false;

			GameObject thePlayer2 = GameObject.Find("hero");
			SimplePlatformController playerScript2 = thePlayer2.GetComponent<SimplePlatformController>();
			playerScript2.selected = true;
			playerScript2.jump = false;

			GameObject thePlayer3 = GameObject.Find("Chicken");
			Chicken playerScript3 = thePlayer3.GetComponent<Chicken>();
			playerScript3.selected = false;
			playerScript3.jump = false;
		}
		else if (Input.GetButtonDown ("Select2")) {
			GameObject thePlayer = GameObject.Find("Pea");
			Pea playerScript = thePlayer.GetComponent<Pea>();
			playerScript.selected = true;
			playerScript.jump = false;
			
			GameObject thePlayer2 = GameObject.Find("hero");
			SimplePlatformController playerScript2 = thePlayer2.GetComponent<SimplePlatformController>();
			playerScript2.selected = false;
			playerScript2.jump = false;

			GameObject thePlayer3 = GameObject.Find("Chicken");
			Chicken playerScript3 = thePlayer3.GetComponent<Chicken>();
			playerScript3.selected = false;
			playerScript3.jump = false;
		}
		else if (Input.GetButtonDown ("Select3")) {
			GameObject thePlayer = GameObject.Find("Pea");
			Pea playerScript = thePlayer.GetComponent<Pea>();
			playerScript.selected = false;
			playerScript.jump = false;
			
			GameObject thePlayer2 = GameObject.Find("hero");
			SimplePlatformController playerScript2 = thePlayer2.GetComponent<SimplePlatformController>();
			playerScript2.selected = false;
			playerScript2.jump = false;

			GameObject thePlayer3 = GameObject.Find("Chicken");
			Chicken playerScript3 = thePlayer3.GetComponent<Chicken>();
			playerScript3.selected = true;
			playerScript3.jump = false;
		}
	}
}
