using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public Transform camera;
    public float startPos;
    public float endPos;
    public float maxHeight;
    public float minHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log((camera.position.y - minHeight) / maxHeight);
        transform.localPosition = new Vector2(Mathf.Lerp(endPos, startPos, (camera.position.y - minHeight) / maxHeight), 0);
        
    }
}
