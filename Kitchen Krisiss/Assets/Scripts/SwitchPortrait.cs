using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwitchPortrait : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Select1")) {
			//gameObject.GetComponent<Image>().color = new Color32(255,255,255,255);
			gameObject.GetComponent<Image>().sprite = Resources.Load ("carrie1", typeof(Sprite)) as Sprite;
		}
		if (Input.GetButtonDown ("Select2")) {
			gameObject.GetComponent<Image>().sprite = Resources.Load ("Eggy", typeof(Sprite)) as Sprite;
		}
		if (Input.GetButtonDown ("Select3")) {
			gameObject.GetComponent<Image>().sprite = Resources.Load ("Chicken", typeof(Sprite)) as Sprite;
		}
	}
}
