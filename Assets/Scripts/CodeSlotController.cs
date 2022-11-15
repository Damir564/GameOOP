using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CodeSlotController : MonoBehaviour
{
    private PlayerController temp;
    public ConsoleController console;
    public int count;

    void Start()
    {
        temp = console.temp_playercontroller;
    }

    public void OnClick()
    {
        /*Array.Clear(temp.function, count, 1);
        Debug.Log(temp.function.Length);*/
        GameObject[] t_arr = new GameObject[console.setted_actions.Length - 1];
        for (int i = 0; i < t_arr.Length; i++)
        {
            if (i >= count)
                t_arr[i] = console.setted_actions[i + 1];
            else
                t_arr[i] = console.setted_actions[i];
        }
        Array.Resize(ref console.setted_actions, console.setted_actions.Length - 1);
        for(int i=0; i< t_arr.Length; i++)
        {
            console.setted_actions[i] = t_arr[i];
        }
    }
}
