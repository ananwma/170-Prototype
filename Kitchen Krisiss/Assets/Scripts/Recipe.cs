using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Recipe : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Image>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnGUI(){
		if (GUI.Button (new Rect (700, 400, 160, 30), "Recipe")) {
			gameObject.GetComponent<Image>().enabled = !(gameObject.GetComponent<Image>().enabled);
			if(gameObject.GetComponent<Image>().enabled){
				Time.timeScale = 0;
			}
			else{
				Time.timeScale = 1;
			}
		}
	}
}
