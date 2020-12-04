using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axis
{
    X,
    Y,
}
public class Parallax : MonoBehaviour
{
    private Vector2 length, startPos, camStartPos;
    public GameObject cam;
    public Vector2 parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        camStartPos = cam.transform.position;
        Debug.Log(startPos);
        length = GetComponent<SpriteRenderer>().bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temp = cam.transform.position * (Vector2.one - parallaxEffect);
        Vector2 dist = cam.transform.position * parallaxEffect;

        transform.position = startPos + dist - camStartPos;
        if (temp.x > startPos.x + length.x) startPos.x += length.x;
        if (temp.x < startPos.x - length.x) startPos.x -= length.x;
    }
}
