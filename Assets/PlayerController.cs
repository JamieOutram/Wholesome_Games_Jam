using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool isJumping;
    CatMovement movement;
    
    void Awake()
    {
        movement = GetComponent<CatMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (movement.state == LaunchingStates.aiming)
            {
                movement.NextState();
            }
            //aiming state -> power state
            //if in aiming state freeze arrow position and start power state
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            if (movement.state == LaunchingStates.power)
            {
                isJumping = true;
                movement.Fling();
                movement.NextState();
            }
            //power state -> stretch state
            //trigger stretch with direction and power

        }
        
    }
}
