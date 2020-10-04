using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encouragement : MonoBehaviour
{
    public Canvas messageCanvas;

    void Start()
    {
        messageCanvas.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "cat")
        {
            TurnOnMessage();
        }
    }

    private void TurnOnMessage()
    {
        messageCanvas.enabled = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "cat")
        {
            TurnOffMessage();
        }
    }

    private void TurnOffMessage()
    {
        messageCanvas.enabled = false;
    }

}
