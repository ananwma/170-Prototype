using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hands : MonoBehaviour {

	public float startingTime = 35f;
	public float currentTime = 35f;

	// Use this for initialization
	void Start () {
	
	}
	public void SetAllCollidersStatus (bool active) {
		foreach(Collider c in GetComponents<Collider> ()) {
			c.enabled = active;
		}
	}
	void OnTriggerEnter2D (Collider2D other){
		/*if (other.gameObject.CompareTag ("Player")) {
			gameObject.GetComponent<Collider2D>().enabled = false;
		}*/
		//gameObject.GetComponent<BoxCollider2D>().enabled = false;
		//SetAllCollidersStatus (false);
	}
	// Update is called once per frame
	void Update () {
		currentTime -= Time.deltaTime;
		if (currentTime < 30f && currentTime > 25f || currentTime < 20f && currentTime > 15f || currentTime < 10f && currentTime > 5f) {
			//descend
			if (Time.timeScale == 1) {
				gameObject.transform.Translate (0, -0.1f, 0);
			}
		} else if (currentTime <= 25f && currentTime > 20f || currentTime <= 15f && currentTime > 10f || currentTime <= 5f) {
			//ascend
			if (Time.timeScale == 1) {
				gameObject.transform.Translate (0, 0.1f, 0);
			}
		}
	}
}
