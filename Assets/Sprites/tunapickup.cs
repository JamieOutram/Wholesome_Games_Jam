using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tunapickup : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("tuna");
        if (other.name == "cat")
        {
            Application.Quit();
            //SceneManager.LoadScene("Game Over");
        }
    }

}
