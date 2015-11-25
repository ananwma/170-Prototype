using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;
	public bool veggiemode = false;

	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;

	public bool selected = true;

	public bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;


	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Enemy")) {
			if (!veggiemode) {
				Application.LoadLevel(Application.loadedLevel);
			}
			if (veggiemode) {	
				//gameObject.GetComponent<BoxCollider2D>().enabled = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (selected) {
			grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

			if (Input.GetButtonDown ("Jump") && grounded) {
				if (!veggiemode)
					jump = true;
			}
			if (Input.GetButtonDown ("VeggieMode")) {
				veggiemode = !veggiemode;
			}
		}
	}	


	void FixedUpdate(){
		if (selected) {
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
					//anim.SetTrigger("Jump");
					rb2d.AddForce (new Vector2 (0f, jumpForce));
					jump = false;
				}
			}
			if (veggiemode) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("carrots1", typeof(Sprite)) as Sprite;
				BoxCollider2D boxCollider = (BoxCollider2D)GetComponent (typeof(BoxCollider2D));
				boxCollider.offset = new Vector2 (0f, 0.3f);
			}
			if (!veggiemode) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("carrie1", typeof(Sprite)) as Sprite;
				BoxCollider2D boxCollider = (BoxCollider2D)GetComponent (typeof(BoxCollider2D));	
				boxCollider.offset = new Vector2 (0.13f, -0.45f);
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
