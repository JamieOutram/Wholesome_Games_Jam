using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //aiming state -> power state
            //if in aiming state freeze arrow position and start power state
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //power state -> stretch state
            //trigger stretch with direction and power

        }
    }
}
