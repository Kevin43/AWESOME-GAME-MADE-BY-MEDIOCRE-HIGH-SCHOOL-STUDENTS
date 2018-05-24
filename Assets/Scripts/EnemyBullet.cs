using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    private int Player_Layer = 9;
    private Animator anim;
    private bool impact = false;    // Lets the animation know if impacted
    private int direction = 0;
    public int speed = 5;

    void OnCollisionEnter2D(Collision2D target)
    {

        if (target.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        bool facingRight = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().facingRight;
        direction = facingRight ? -1 : 1;
        Destroy(this.gameObject, 1.5f);
    }
	
	// Update is called once per frame
	void Update () {
        if (impact)
        {                               // on impact the object is destroyed with animation
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Destroy(this.gameObject, 0.01f);    // destroys after animation time
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(direction * speed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == Player_Layer)
        {
            //anim.SetTrigger("impact");          // animation impact
            impact = true;                      // local impact trigger
        }
    }
}
