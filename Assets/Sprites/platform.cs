using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class platform : MonoBehaviour
{


    public float limits = 4f; 
    public float moveSpeed = 3f;
    bool moveRight = true;
    public float playerHeight;
    Rigidbody2D catPaws;
    Rigidbody2D catFeet;
    float direction;
    
    private void Start()
    {
        direction = 1;

    }

    //call once per frame
    private void FixedUpdate()
    {
        if (transform.position.x > limits)
        {
            direction = -1;
        }
        if (transform.position.x < -limits)
        {
            direction = 1;
        }
        transform.position += new Vector3(direction * moveSpeed * Time.fixedDeltaTime, 0);
        //Debug.Log(catPaws);
        if (catPaws != null && !PlayerController.isJumping)
            catPaws.position += new Vector2(direction * moveSpeed * Time.fixedDeltaTime, 0);
        if (catFeet != null && !PlayerController.isJumping)
            catFeet.position += new Vector2(direction * moveSpeed * Time.fixedDeltaTime, 0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Platform OnCollisionEnter Called");
        Debug.Log(string.Format("Height: {0} Max Bounds: {1}", collision.rigidbody.position.y, collision.otherCollider.bounds.max.y + playerHeight));
        if (collision.rigidbody.position.y > collision.otherCollider.bounds.max.y+playerHeight)
        {
            if (collision.collider.CompareTag("Head"))
            {
                catPaws = collision.rigidbody;
                Debug.Log("dragging player head");
            }

            if (collision.collider.CompareTag("Butt"))
            {
                catFeet = collision.rigidbody;
                Debug.Log("dragging player feet");
            }
        }
            
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("OnCollisionExit2D called");
        Debug.Log("Platform OnCollisionExit Called");
        if (collision.collider.CompareTag("Butt"))
        {
            catFeet = null;
            PlayerController.isJumping = false;
        }
        else if (collision.collider.CompareTag("Head"))
            catPaws = null;
        
        
    }

}
