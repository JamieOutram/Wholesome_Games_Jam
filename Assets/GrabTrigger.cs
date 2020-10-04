using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTrigger : MonoBehaviour
{
    public CatMovement movement;
    private static Collider2D grabbedObj;

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("OnCollisionEnterCalled");
        if (!ReferenceEquals(grabbedObj, collider))
        {
            if (collider.CompareTag("Grabable"))
            {
                movement.Grab();
                grabbedObj = collider;
            }
        }
    }

    public static void ResetGrab()
    {
        grabbedObj = null;
    }

}
