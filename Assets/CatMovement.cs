using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.Rendering;

public enum LaunchingStates
{
    flying,
    idle,
    aiming,
    power,
}

public class CatMovement : MonoBehaviour
{
    public float arcOffset;
    public float rotationSpeed;
    public Rigidbody2D head;
    public Rigidbody2D feet;
    public GameObject launcher;
    public MaskAnimation PowerBarMask;


    public LaunchingStates state;
    Animator launcherAnimator;
    //float currentAngle;
    int rotateDirection;
    // Start is called before the first frame update
    void Start()
    {
        rotateDirection = 1;
        launcherAnimator = launcher.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(string.Format("CurrentAngle:{0}", currentAngle));
        //currentAngle = Vector2.SignedAngle(Vector2.left, (Vector2)launcher.transform.position - feet.position);
        switch (state)
        {
            case LaunchingStates.aiming:
                if (launcher.transform.position.y <= feet.position.y + arcOffset)
                    rotateDirection = -rotateDirection;
                launcher.transform.RotateAround(feet.transform.position, Vector3.forward, rotationSpeed * rotateDirection);
                break;
        }
        
    }

    public void NextState()
    {
        switch (state)
        {
            case LaunchingStates.aiming:
                SetState(LaunchingStates.power);
                break;
            case LaunchingStates.power:
                SetState(LaunchingStates.flying);
                break;
            case LaunchingStates.flying:
                SetState(LaunchingStates.aiming);
                break;
            default:
                Debug.LogError("Launching State Error");
                break;
        }
    }

    public void SetState(LaunchingStates state)
    {
        this.state = state;
        switch (state)
        {
            case LaunchingStates.power:
                launcherAnimator.SetBool("Aiming", false);
                launcherAnimator.SetBool("Powering", true);
                launcherAnimator.SetBool("Flying", false);
                PowerBarMask.ResetMask();
                break;
            case LaunchingStates.flying:
                launcherAnimator.SetBool("Powering", false);
                launcherAnimator.SetBool("Flying", true);
                launcherAnimator.SetBool("Aiming", false);
                break;
            case LaunchingStates.aiming:
                launcherAnimator.SetBool("Flying", false);
                launcherAnimator.SetBool("Aiming", true);
                launcherAnimator.SetBool("Powering", false);
                break;
            default:
                Debug.LogError("Launching State Error");
                break;
        }
    }


    
}
