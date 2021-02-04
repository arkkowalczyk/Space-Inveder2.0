using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        text.text = "Points: " + Handler.ScoreCount;
    }
}
