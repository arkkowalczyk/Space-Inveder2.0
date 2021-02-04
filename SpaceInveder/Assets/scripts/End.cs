using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    void Update()
    {
        if (Handler.GState==Handler.GameState.over)
        {
            Destroy(this.gameObject);
        }
    }
}
