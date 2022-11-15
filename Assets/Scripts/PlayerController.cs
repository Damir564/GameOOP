using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(Outline))]
//[RequireComponent(typeof(ConsoleOpenner))]
public class PlayerController : MonoBehaviour
{

    public GameObject[] function = new GameObject[0];
    public GameObject[] setted_actions = new GameObject[0];

    public Transform player;
    public Vector3 offset;
    public Outline outline;
    //public ConsoleOpenner console;
    public bool object_can_move;
    public float carSpeed;

    private int k;
    private float distanceCounter = 0;

    public int distance;

    // Start is called before the first frame update
    void Start()
    {
        object_can_move = false;
        k = 0;


        player = GetComponent<Transform>();
        outline = GetComponent<Outline>();
        //console = GetComponent<ConsoleOpenner>();
        outline.OutlineWidth = 0f;
        outline.OutlineColor = Color.white;
        outline.OutlineMode = Outline.Mode.OutlineVisible;
    }

    // Update is called once per frame
    void Update()
    {
        /*offset.x = Input.GetAxis("Horizontal") * carSpeed;
        offset.z = Input.GetAxis("Vertical") * carSpeed;
        offset.y = 0f;
        transform.position = player.position + offset;
        if (Input.GetMouseButtonDown(1))
        {
            offset.x = 0;
            offset.y = 0;
            offset.z = 0;
            transform.position = offset;
            Array.Resize(ref setted_actions, 0);
        }*/
        if (object_can_move && setted_actions.Length != 0 && k < setted_actions.Length) 
        {
            if (setted_actions[k].name == "GoAhead")
            {
                offset.x = 0f;
                offset.y = 0f;
                offset.z = carSpeed;
                transform.position = player.position + offset;
                distanceCounter += carSpeed;
                if (distanceCounter == distance)
                {
                    distanceCounter = 0;
                    k++;
                }
            }else if (setted_actions[k].name == "GoBack")
            {
                offset.x = 0;
                offset.y = 0f;
                offset.z = -carSpeed;
                transform.position = player.position + offset;
                distanceCounter += carSpeed;
                if (distanceCounter == distance)
                {
                    distanceCounter = 0;
                    k++;
                }
            }
        }
        else
        {
            k = 0;
            object_can_move = false;
        }
    }
}
