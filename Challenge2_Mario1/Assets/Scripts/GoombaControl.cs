using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaControl : MonoBehaviour {

    public float speed;

    public float wallHitWidth;

    public float wallHitHeight;

    public float playerHitHeight;

    public float playerHitWidth;

    public Transform wallHitCheck;

    public Transform playerHitBox;

    public LayerMask isPlayer;

    public LayerMask isGround;


    private bool wallHit;

    private bool playerHit;

    private Rigidbody2D rb2d;

    private bool facingRight = true;

    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();


        anim.SetBool("isDead", false);

        playerHit = false;
       

        rb2d = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

    }


     void OnCollisionStay2D(Collision2D collision)
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

        if (collision.collider.tag == "player"){
            anim.SetBool("isDead", true);
            Debug.Log("Th-Th-The, Th-Th-The, Th-Th.. that's all folks!");
            Destroy(gameObject);
        }
    }
     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawCube(wallHitCheck.position, new Vector3(wallHitWidth, wallHitHeight, 1));
 
        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(playerHitBox.position, new Vector3(playerHitWidth, playerHitHeight, 1));
    }
}

