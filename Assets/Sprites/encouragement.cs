using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Critter
{
    pidge,
    doreen,
    squirrel,
    worm,
    catbro,
}

public class encouragement : MonoBehaviour
{
    public Canvas messageCanvas;
    public Critter whatAmI;
    public int convoNumber;

    private int lineNumber;

    

    void Start()
    {
        messageCanvas.enabled = false;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Head"))
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
        if (other.CompareTag("Head"))
        {
            TurnOffMessage();
        }
    }

    private void TurnOffMessage()
    {
        messageCanvas.enabled = false;
    }

    private void UpdateMessage()
    {
        switch (whatAmI)
        {
            case Critter.catbro:
                switch (convoNumber)
                {

                }
                
                break;
            case Critter.doreen:
                break;
            case Critter.pidge:
                break;
            case Critter.squirrel:
                break;
            case Critter.worm:
                break;
        }
    }

}
