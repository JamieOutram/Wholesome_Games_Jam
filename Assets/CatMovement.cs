using DG.Tweening;

using UnityEngine;

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
    public float maxLaunchDistance;
    public float extendTime;
    public float hangDistance;
    public Rigidbody2D head;
    public Rigidbody2D feet;
    public Collider2D feetCollider;
    public GameObject launcher;
    public MaskAnimation PowerBarMask;

    public LaunchingStates state;


    bool isFalling;
    Tween tw;
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
                if (launcher.transform.position.y <= head.position.y + arcOffset)
                {
                    if (launcher.transform.position.x < head.position.x)
                        rotateDirection = -1;
                    else
                        rotateDirection = 1;
                }
                    
                launcher.transform.RotateAround(head.transform.position, Vector3.forward, rotationSpeed * rotateDirection * Time.deltaTime);
                break;
            case LaunchingStates.power:

                break;
            case LaunchingStates.flying:
                if (isFalling)
                {
                    if (Mathf.Abs(head.velocity.y) <= 0.01f)
                    {
                        isFalling = false;
                        feetCollider.isTrigger = true;
                        tw = feet.DOMove(head.transform.position, extendTime).SetEase(Ease.OutQuad).OnComplete(OnFollowComplete);
                    }
                }
                break;
            default:
                Debug.LogException(new System.Exception("Launching State Error has occured"));
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

    public void Fling()
    {
        HoldPosition(false);
        Vector2 path = launcher.transform.localPosition.normalized * PowerBarMask.transform.localScale.x * maxLaunchDistance;
        tw = head.DOMove((Vector2)head.transform.position + path, extendTime).SetEase(Ease.OutQuad).OnComplete(OnFlingEnd);
    }

    void OnFlingEnd()
    {
        isFalling = true;
        head.velocity = Vector2.zero;
        feet.velocity = Vector2.zero;
        GrabTrigger.ResetGrab();
    }

    void OnFollowComplete()
    {
        feetCollider.isTrigger = false;

        SetState(LaunchingStates.aiming);
    }

    public void CancelFling()
    {
        if (tw != null)
        {
            if (tw.active)
            {
                tw.Kill();
                OnFlingEnd();
            }
        }
    }

    public void Grab()
    {
        Debug.Log("Grab Called");
        if(tw != null)
        {
            if (tw.active) {
                tw.Kill();   
            }
        }
        isFalling = false;
        feetCollider.isTrigger = true;
        tw = feet.DOMove(head.transform.position-Vector3.up*hangDistance, extendTime).SetEase(Ease.OutQuad).OnComplete(OnFollowComplete);
        HoldPosition(true);

    }
    
    public void HoldPosition(bool hold)
    {
        if (hold)
        {
            head.gravityScale = 0;
            head.velocity = Vector2.zero;
            feet.gravityScale = 0;
            feet.velocity = Vector2.zero;
        }
        else
        {
            head.gravityScale = 1;
            feet.gravityScale = 1;
        }
    }

}
