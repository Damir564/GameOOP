using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerButton : MonoBehaviour
{
    public ScreenPlane screen;
    public bool consoleIsClosed;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == gameObject.name)
                {
                    //screen.consoleNotEnabled = true;
                    consoleIsClosed = true;
                }
            }
        }
    }
}
