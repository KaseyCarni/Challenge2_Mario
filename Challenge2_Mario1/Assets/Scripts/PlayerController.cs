using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;

    private Animator anim;

    private bool facingRight = true;

    private bool isOnGround;

    private AudioSource source;

    private float volLowRange = .5f;

    private float volHighRange = 1.0f;


    public float speed;

    public AudioClip coinClip;

    public AudioClip jumpClip;

    public float jumpforce;

    public Transform groundcheck;

    public float checkRadius;

    public LayerMask allGround;



    void Start(){


    rb2d = GetComponent<Rigidbody2D>();

        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;

        anim = GetComponent<Animator>();
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }



    void Update(){
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {

            anim.SetBool("isRunning", true);

        }
        else {

            anim.SetBool("isRunning", false);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            anim.SetTrigger("Jumping");
        }



    }

    void FixedUpdate(){

        float moveHorizontal = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);

        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PickUp")){

            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(coinClip);

            other.gameObject.SetActive(false);
        }

    }
   

    void Flip()
    {
        facingRight = !facingRight;

        Vector2 Scaler = transform.localScale;

        Scaler.x = Scaler.x * -1;

        transform.localScale = Scaler;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" && isOnGround)
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(jumpClip); 

                rb2d.velocity = Vector2.up * jumpforce;

            }
        } 
             
    }
}
