using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class platform : MonoBehaviour
{
    
    
    float dirX, moveSpeed = 3f;
    bool moveRight = true;
    public float playerHeight;
    Transform cat;
    float direction;
    private void Start()
    {
        direction = 1;

    }

    //call once per frame
    private void Update()
    {
        if (transform.position.x > 4f)
        {
            direction = -1;
        }
        if (transform.position.x < -4f)
        {
            direction = 1;
        }
        transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0);
        if (cat != null && !PlayerController.isJumping)
            cat.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Platform OnCollisionEnter Called");
        Debug.Log(string.Format("Height: {0} Max Bounds: {1}", collision.rigidbody.position.y, collision.otherCollider.bounds.max.y + playerHeight));
        if (collision.rigidbody.position.y > collision.otherCollider.bounds.max.y+playerHeight)
        {
            cat = collision.transform;
            Debug.Log("dragging player");
            
        }
            
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Platform OnCollisionExit Called");
        
        cat = null;
        PlayerController.isJumping = false;
        
    }

}
