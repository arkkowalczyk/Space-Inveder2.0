using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScale : MonoBehaviour
{
    [SerializeField] SpriteRenderer area;
    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = area.bounds.size.x / area.bounds.size.y;

        if (screenRatio>=targetRatio)
        {
            Camera.main.orthographicSize = area.bounds.size.y / 2;
        }
        else
        {
            float diffrenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = area.bounds.size.y / 2 * diffrenceInSize;
        }
    }

}
