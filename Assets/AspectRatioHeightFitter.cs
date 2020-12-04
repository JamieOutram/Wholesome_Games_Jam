using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AspectRatioHeightFitter : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;
    private float scaleAspect;

    #if UNITY_EDITOR
    private Vector2 resolution;
    #endif //UNITY_EDITOR


    private Resolution res;

    private void Awake()
    {
        #if UNITY_EDITOR
        resolution = new Vector2(Screen.width, Screen.height);
        #endif //UNITY_EDITOR

    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        scaleAspect = transform.localScale.x / transform.localScale.y;
        UpdateSize();
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        if (resolution.x != Screen.width || resolution.y != Screen.height)
        {
            UpdateSize();
            resolution.x = Screen.width;
            resolution.y = Screen.height;
        }
        #endif //Unity_Editor
    }

    void UpdateSize()
    {
        Vector2 screenBottomLeftInWorld = mainCamera.ScreenToWorldPoint(new Vector2(0, 0));
        Vector2 screenTopRightInWorld = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        float y1 = screenTopRightInWorld.y-screenBottomLeftInWorld.y;
        float y2 = spriteRenderer.bounds.size.y;
        Debug.Log("Camera Height: " + y1 + " Sprite Height: " + y2);
        float newHeightScale = transform.localScale.y*(1 - (y2 - y1) / y2);
        float newWidthScale = newHeightScale * scaleAspect;
        transform.localScale = new Vector2(newWidthScale, newHeightScale);
    }


}
