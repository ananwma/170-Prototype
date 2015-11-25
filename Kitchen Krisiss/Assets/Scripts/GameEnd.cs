using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<Image> ().enabled = false;
	}
	

	// Update is called once per frame
	void Update () {
		GameObject thePlayer = GameObject.Find("Pea");
		Pea playerScript = thePlayer.GetComponent<Pea>();
		if (playerScript.success == 1) {
			gameObject.GetComponent<Text>().text = "WIN";
			gameObject.GetComponent<Text>().color = Color.green;
		}
		if (playerScript.success == -1) {
			gameObject.GetComponent<Text>().text = "LOSE";
			gameObject.GetComponent<Text>().color = Color.red;
		}
	}
}
