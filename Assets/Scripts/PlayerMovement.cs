using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Transform groundCheck;

    public float jumpForce = 120f;
    public float playerSpeed = 0f;
    public float move;
    public float groundRadius = 0.2f;
    private float busterPos;
    private float fireModeTime;
    public bool stunned = false;
    public bool facingRight = true;
    public bool grounded = false;
    public LayerMask whatIsGround;
    private Animator anim;

	// Use this for initialization
	void Start () {

        playerSpeed = 3f;
        anim = GetComponent<Animator>();
        anim.SetBool("Spawning", false);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        float move = Input.GetAxis("Horizontal");
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(move));

        if (move < 0) GetComponent<Rigidbody2D>().velocity = new Vector3(move * playerSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (move > 0) GetComponent<Rigidbody2D>().velocity = new Vector3(move * playerSpeed, GetComponent<Rigidbody2D>().velocity.y);

        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        /*if (grounded && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            //schedulePlay(sound.mm_jump);
            anim.SetBool("Grounded", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }*/
        //if (stunned)
        //    move = 0;
        //else
        //    move = 1;


        //GetComponent<Rigidbody2D>().velocity = new Vector2(move * playerSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }
    void Update ()
    {

        if (!stunned)
            checkInputs();

        if (fireModeTime <= Time.time)
        {
            fireModeTime = 0f;
            anim.SetBool("FireMode", false);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void checkInputs()
    {
        // Fire check
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //schedulePlay(sound.mm_burst);
            anim.SetBool("FireMode", true);     // sets fire mode for animations
            anim.SetTrigger("Fire");
            fireModeTime = Time.time + 0.5f;    // sets fire mode for animations locally

            // if facing right, the buster shot must also
            busterPos = facingRight ? 0.3f : -0.3f;
            //Instantiate(buster, new Vector3(transform.position.x + busterPos, transform.position.y + 0.04f, 0f), Quaternion.identity);
        }
        // Jump Check
        if (grounded && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            //schedulePlay(sound.mm_jump);
            anim.SetBool("Grounded", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }
}
