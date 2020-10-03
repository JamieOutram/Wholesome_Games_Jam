using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchBody : MonoBehaviour
{
    public Transform feet;
    public Transform head;
    SpriteRenderer sprite;
    public float bodySizeOffset;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (head.position - feet.position)/2 + feet.position;
        transform.rotation = Quaternion.Euler(0,0, Vector2.SignedAngle(Vector2.up, head.position - feet.position));
        sprite.size = new Vector2(1, (head.position - feet.position).magnitude + bodySizeOffset);

    }
}
