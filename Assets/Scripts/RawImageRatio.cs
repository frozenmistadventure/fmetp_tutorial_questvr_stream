using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RawImageRatio : MonoBehaviour
{
    [SerializeField] private RawImage rimg;

    private float screenWidth;
    private float screenHeight;
    private float screenAspect;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        screenAspect = screenWidth / screenHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if (rimg.texture == null) return;

        float textureWidth = rimg.texture.width;
        float textureHeight = rimg.texture.height;
        float textureAspect = textureWidth / textureHeight;

        Vector3 scale = new Vector3(1f, 1f, 1f);
        if(screenAspect > textureAspect)
        {
            //wider screen..
            scale.x = textureAspect / screenAspect;
        }
        if (screenAspect < textureAspect)
        {
            //wider screen..
            scale.y = screenAspect / textureAspect;
        }

        rimg.transform.localScale = scale;
        
    }
}
