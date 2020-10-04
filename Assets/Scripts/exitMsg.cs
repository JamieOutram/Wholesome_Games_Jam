using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitMsg : MonoBehaviour
{
    [SerializeField] GameObject exitPanel;

    public void onUserClickStart()
    {
        TransitionBehaviour.TriggerFade("Start Menu");
        //SceneManager.LoadScene("Start Menu");
    }

    public void onUserClickCredit()
    {
        TransitionBehaviour.TriggerFade("End Credits");
        //SceneManager.LoadScene("End Credits");
    }
}
