using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionBehaviour : MonoBehaviour
{
    
    static Animator anim;

    static string nextScene;
    bool isFading;
    bool fadeTrigger;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        if (anim.GetBool("Black") && !anim.GetBool("Fade"))
        {
            if (nextScene != null)
                SceneManager.LoadScene(nextScene);
            anim.SetBool("Fade", true);
        }

    }

    public static void TriggerFade(string scene) 
    {
        nextScene = scene;
        anim.SetBool("Fade", true);
    }
}
