using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tunapickup : MonoBehaviour
{

    public Canvas exitCanvas;

    void Start()
    {
        exitCanvas.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
            TurnOnExit();
    }

    private void TurnOnExit()
    {
        exitCanvas.enabled = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
            TurnOffExit();
    }

    private void TurnOffExit()
    {
        exitCanvas.enabled = false;
    }
}
