using UnityEngine;
using System.Collections;

public class Chicken : MonoBehaviour{
	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;
	public bool veggiemode = true;
	public bool awakened = false;
	
	public bool selected = false; 
	
	public int success = 0;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;
	
	public static float startingTime;
	public static float endingTime;
	
	public bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;
	private bool jumped;
	
	
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	
	void OnTriggerEnter2D (Collider2D other){
		if (!awakened) {
			if (other.gameObject.CompareTag ("Player")) {
				//Destroy(gameObject);
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Chicken");
				veggiemode = false;
				awakened = true;
			}
		}
		if (other.gameObject.CompareTag ("Enemy")) {
			if (!veggiemode) {
				Application.LoadLevel(Application.loadedLevel);
			}
			if (veggiemode) {	
				//gameObject.GetComponent<Collider2D>().enabled = false;
			}
		}
	}
	
	void Update () {
		if (selected) {
			grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
			if (Input.GetButtonDown ("Jump") && grounded) {
				if (!veggiemode && awakened)
					jump = true;
			}
			if (Input.GetButtonDown ("VeggieMode")) {
				veggiemode = !veggiemode;
			}
			if (!awakened) {
				Vector3 position = transform.position;
				position.x = 3;
			}
		}
	}	
	void FixedUpdate(){
		if (success == 0 && selected) {
			if (awakened) {
				float h = Input.GetAxis ("Horizontal");
				anim.SetFloat ("Speed", Mathf.Abs (h));
				if (!veggiemode) {
					if (h * rb2d.velocity.x < maxSpeed)
						rb2d.AddForce (Vector2.right * h * moveForce);
					if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
						rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
					if (h > 0 && !facingRight)
						Flip ();
					else if (h < 0 && facingRight)
						Flip ();
					if (jump) {
						rb2d.AddForce (new Vector2 (0f, jumpForce));
						jump = false;
						jumped = true;
					}
				}
				if (veggiemode && awakened) {
					gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("ChickenV", typeof(Sprite)) as Sprite;
					//gameObject.GetComponent<CircleCollider2D> ().enabled = false;
				}
				if (!veggiemode && awakened) {
					gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("Chicken", typeof(Sprite)) as Sprite;
				}
			}
		}
	}
	
	void Flip(){
		if (veggiemode)
			return;
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

