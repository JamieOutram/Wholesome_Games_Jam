using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MaskAnimation : MonoBehaviour
{
    public float scaleSpeed = 0.1f;
    public float offsetSpeed = 0.05f;

    private float startOffset;
    private int direction;
    // Start is called before the first frame update
    void Start()
    {
        startOffset = transform.localPosition.x;
        ResetMask();
    }

    // Update is called once per frame
    void Update()
    {
        float nextScale = transform.localScale.y + scaleSpeed*direction*Time.deltaTime;
        nextScale = Mathf.Clamp(nextScale, 0, 1);
        if(nextScale == 1) direction = -1;
        else if (nextScale == 0) direction = 1;
        transform.localScale = new Vector3(1,nextScale,1);
        transform.localPosition += Vector3.right*offsetSpeed*direction*Time.deltaTime;

    }

    public void ResetMask()
    {
        transform.localScale = Vector3.zero;
        transform.localPosition = new Vector3(startOffset, 0, 0);
        direction = 1;
    }
}
