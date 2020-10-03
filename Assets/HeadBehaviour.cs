using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBehaviour : MonoBehaviour
{
    public CatMovement movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Head Behaviour OnCollisionEnterCalled");
        if(!collision.transform.CompareTag("OneWayPlatform"))
            movement.CancelFling();
    }
}
