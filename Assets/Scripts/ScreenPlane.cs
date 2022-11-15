using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPlane : MonoBehaviour
{

    private Camera cam;
    private float rotationSpeed;
    private float curRotation;

    public Transform pos;
    public bool consoleNotEnabled;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        pos = GetComponent<Transform>();
        rotationSpeed = 1f;
        curRotation = 0f;
        consoleNotEnabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pos.rotation = cam.transform.rotation;
        pos.Rotate(-90f, curRotation, 0f);
        pos.position = cam.transform.position + cam.transform.forward * 7f - cam.transform.up * 2f + cam.transform.right * 7.4f;
        if(consoleNotEnabled && curRotation < 180)
        {
            curRotation += rotationSpeed;
        }
        if(!consoleNotEnabled && curRotation > 0)
        {
            curRotation -= rotationSpeed;
        }
    }
}
