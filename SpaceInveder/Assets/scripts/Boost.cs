using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boost : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image img;
    [SerializeField] float cd = 40.0f, acitveTime = 5f, multi = 2f;
    bool canUse = false, active = false;
    float timer = 0f;

    private void FixedUpdate()
    {
        img.fillAmount += 1.0f / cd * Time.fixedDeltaTime;
    }
    void Update()
    {
        
        if (img.fillAmount == 1)
        {
            canUse = true;
        }
        timer -= Time.deltaTime;
        if (active && timer <= 0)
        {
            player.ShootSpeed *= multi;
            active = false;
        }

    }
    public void UseBoost()
    {
        if (canUse)
        {
            img.fillAmount = 0;
            canUse = false;
            player.ShootSpeed /= multi;
            active = true;
            timer = acitveTime;
        }
    }
}
