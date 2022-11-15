using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FunctionSlotController : MonoBehaviour
{
    public ConsoleController temp;
    public int count;


    public void OnClick()
    {
        if (temp.setted_actions.Length <= 7)
        {
            Array.Resize(ref temp.setted_actions, temp.setted_actions.Length + 1);
            temp.setted_actions[temp.setted_actions.Length - 1] = temp.temp_playercontroller.function[count];
        }
    }
}
