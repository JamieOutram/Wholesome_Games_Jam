using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text text;
    private int lineNumber;
    private string line;
    

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
        UpdateMessage();
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
                line = CritterLines.catbroLines[convoNumber, CritterLines.catbroCount];
                CritterLines.catbroCount++;
                if (CritterLines.catbroCount >= CritterLines.catbroLines.GetLength(1))
                {
                    CritterLines.catbroCount = 0;
                }
                break;
            case Critter.doreen:
                line = CritterLines.doreenLines[convoNumber, CritterLines.doreenCount];
                CritterLines.doreenCount++;
                if (CritterLines.doreenCount >= CritterLines.doreenLines.GetLength(1))
                {
                    CritterLines.doreenCount = 0;
                }
                break;
            case Critter.pidge:
                line = CritterLines.pidgeLines[convoNumber, CritterLines.pidgeCount];
                CritterLines.pidgeCount++;
                if (CritterLines.pidgeCount >= CritterLines.pidgeLines.GetLength(1))
                {
                    CritterLines.pidgeCount = 0;
                }
                break;
            case Critter.squirrel:
                line = CritterLines.squirrelLines[convoNumber, CritterLines.squirrelCount];
                CritterLines.squirrelCount++;
                if (CritterLines.squirrelCount >= CritterLines.squirrelLines.GetLength(1))
                {
                    CritterLines.squirrelCount = 0;
                }
                break;
            case Critter.worm:
                line = CritterLines.wormLines[convoNumber, CritterLines.wormCount];
                CritterLines.wormCount++;
                if (CritterLines.wormCount >= CritterLines.wormLines.GetLength(1))
                {
                    CritterLines.wormCount = 0;
                }
                break;
        }
        text.text = line;

    }

}
