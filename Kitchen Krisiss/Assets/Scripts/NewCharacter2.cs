using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewCharacter2 : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Image> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject thePlayer = GameObject.Find("Chicken");
		Chicken playerScript = thePlayer.GetComponent<Chicken>();
		if (playerScript.awakened == true) {
			gameObject.GetComponent<Image> ().enabled = true;
		}
	}
}
