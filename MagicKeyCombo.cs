using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicKeyCombo
{
    public String[] buttons;
    private int currentIndex = 0;
    public float allowedDelay = 0.5f;
    private float lastTime;

    public MagicKeyCombo(String[] b)
    {
        buttons = b;
    }

    public bool check()
    {
        if (Time.time > lastTime + allowedDelay)
        {
            currentIndex = 0;
        }
        if (currentIndex < buttons.Length)
        {
            if (Input.GetKeyDown(buttons[currentIndex]))
            {
                lastTime = Time.time;
                currentIndex++;
            }
            if (currentIndex >= buttons.Length)
            {
                currentIndex = 0;
                return true;
            }
            return false;
        }
        return false;
    }

}
