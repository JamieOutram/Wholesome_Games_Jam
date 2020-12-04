using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float minHeight;
    public GameObject player;
    [SerializeField] private float verticalOffset;
    

    // Start is called before the first frame update
    void Awake()
    {
        minHeight = transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(minHeight > player.transform.position.y + verticalOffset)
            transform.position = new Vector3(player.transform.position.x, minHeight, -10);
        else 
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + verticalOffset, -10);
    }

}
