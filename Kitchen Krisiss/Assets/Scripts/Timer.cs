using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public Image WarningImage;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f,0f,0f,0.1f);

	private Text timeText;
	public float startingTime = 35f;
	public float currentTime = 35f;

	// Use this for initialization
	void Start () {
		timeText = GameObject.Find("TimeText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		WarningImage = GameObject.Find("WarningImage").GetComponent<Image>();
		currentTime -= Time.deltaTime;
		timeText.text = ""+Mathf.FloorToInt(currentTime);
		if (currentTime <= 0) {
			Application.LoadLevel(Application.loadedLevel);
		}
		else if (currentTime <= 5) {
			WarningImage.color = flashColour;
		} 
		else {
			WarningImage.color = Color.Lerp(WarningImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
	}
}
