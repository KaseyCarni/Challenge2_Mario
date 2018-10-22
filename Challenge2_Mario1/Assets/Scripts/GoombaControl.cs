using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaControl : MonoBehaviour {

    public float speed;

    public float wallHitWidth;

    public float wallHitHeight;

    public float playerHitHeight;

    public float playerHitWidtht;

    public Transform playerHitBox;

    public Transform wallHitCheck;

    public LayerMask allWall;

    public LayerMask isGround;


    private bool wallHit;

    private bool playerHit;

    private Rigidbody2D rb2d;

    private bool facingRight = true;

    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();

       // I tried to get this to work

        playerHit = false;

        rb2d = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        wallHit = Physics2D.OverlapBox(wallHitCheck.position, new Vector2(wallHitWidth, wallHitHeight), 0, isGround);

        if (wallHit == true)
        {
            speed = speed * -1;

            facingRight = !facingRight;

            Vector2 Scaler = transform.localScale;

            Scaler.x = Scaler.x * -1;

            transform.localScale = Scaler;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && playerHit == true)
        {
            anim.SetBool("isDead", true);
            Debug.Log("Goomba dead");
            Destroy(gameObject);
        }
    }
}
