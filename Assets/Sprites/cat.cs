using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 20;
    private float dirX, dirY;
    public float distance;
    public float jumpForce = 10;
    public LayerMask whatIsLadder, whatIsGround;
    private bool isClimbing;

    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;

    private float jumpCounter;
    public float jumpStop;
    private bool isJumping;

    //init
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        //if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
        // rb.AddForce(Vector2.up * 500f);

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        if(hitInfo.collider != null)
        {
            if (Input.GetKey(KeyCode.UpArrow)|Input.GetKey(KeyCode.W))
            {
                isClimbing = true;
            }
        } else{
            isClimbing = false;
        }

        if(isClimbing == true)
        {
            dirY = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.position.x, dirY * moveSpeed);
            rb.gravityScale = 0;
        } else{
            rb.gravityScale = 5;
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpCounter = jumpStop;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpCounter -= Time.deltaTime;
            }
        }
        else
        {
            isJumping = false; 
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("platform"))
            this.transform.parent = collision.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("platform"))
            this.transform.parent = null;
    }
}
