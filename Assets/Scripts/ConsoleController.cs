using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ConsoleController : MonoBehaviour
{
    public Camera cam;
    private bool if_console_openned;
    public Outline outline;
    public PlayerController temp_playercontroller;
    private ScreenPlane plane;
    public GameObject[] functionslots = new GameObject[7];
    public GameObject[] codeslots = new GameObject[8];

    public GameObject[] setted_actions = new GameObject[0];
    
    public PowerButton offButton;
    public bool objectCanMove;
    public int sizeOfActions;

    private int previousSizeOfActions;
    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        if_console_openned = false;
        plane = GetComponent<ScreenPlane>();

        sizeOfActions = 0;
        previousSizeOfActions = 0;
        objectCanMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!if_console_openned)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.TryGetComponent<PlayerController>(out PlayerController component))
                {
                    temp_playercontroller = component;
                    component.outline.OutlineWidth = 3f;
                    if (Input.GetMouseButtonDown(0))
                    {
                        if_console_openned = true;
                        component.outline.OutlineColor = Color.green;
                        plane.consoleNotEnabled = false;
                        for(int i = 0; i < component.function.Length; i++)
                        {
                            //Instantiate(component.function[i], parent.position + parent.up * 1.71f - parent.up * 0.4915f * i, parent.rotation, parent);
                            functionslots[i].GetComponent<Image>().color = Color.gray;
                            functionslots[i].GetComponentInChildren<Text>().text = component.function[i].name;
                            functionslots[i].GetComponent<Button>().interactable = true;
                        }
                        Array.Resize(ref setted_actions, component.setted_actions.Length);
                        for (int i = 0; i < setted_actions.Length; i++)
                        {
                            setted_actions[i] = component.setted_actions[i];
                        }
                    }
                    if (!if_console_openned)
                    {
                        component.outline.OutlineColor = Color.white;
                    }
                }
                else
                {
                    temp_playercontroller.outline.OutlineWidth = 0f;
                }
            }
        }
        //pos.position = cam.transform.position + cam.transform.forward * 4.6f + cam.transform.right * 6.3f - cam.transform.up * 4f;
        /*if (sizeOfActions != previousSizeOfActions)
        {
            ScriptableObject.Destroy(actions[0]);
        }*/
        if (if_console_openned)
        {
            RefreshActions();
            for (int i = 0; i < setted_actions.Length; i++)
            {
                codeslots[i].GetComponent<Image>().color = Color.white;
                codeslots[i].GetComponentInChildren<Text>().text = setted_actions[i].name;
                codeslots[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    public void Play()
    {
        /*offButton.consoleIsClosed = true;
        objectCanMove = true;*/
        temp_playercontroller.object_can_move = true;
        plane.consoleNotEnabled = true;
        if_console_openned = false;
        temp_playercontroller.outline.OutlineWidth = 0f;
        temp_playercontroller.outline.OutlineColor = Color.white;
    }

    public void RefreshActions()
    {
        for (int i = 0; i < 8; i++)
        {
            codeslots[i].GetComponent<Image>().color = Color.gray;
            codeslots[i].GetComponentInChildren<Text>().text = "";
            codeslots[i].GetComponent<Button>().interactable = false;
        }
        Array.Resize(ref temp_playercontroller.setted_actions, setted_actions.Length);
        for (int i = 0; i < setted_actions.Length; i++)
        {
            temp_playercontroller.setted_actions[i] = setted_actions[i];
        }
    }
}
