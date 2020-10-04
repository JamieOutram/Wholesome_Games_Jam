using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitMsg : MonoBehaviour
{
    [SerializeField] GameObject exitPanel;

    public void onUserClickStart()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void onUserClickCredit()
    {
        SceneManager.LoadScene("End Credits");
    }
}
