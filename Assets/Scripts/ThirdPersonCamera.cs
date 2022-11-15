using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonCamera : MonoBehaviour
{
    CinemachineFreeLook freeLookComponent;
    public float mouseSensitivity = 100f;
    

    void Awake()
    {
        freeLookComponent = GetComponent<CinemachineFreeLook>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            freeLookComponent.m_XAxis.m_MaxSpeed = 3*mouseSensitivity;
        }    
        if (Input.GetMouseButtonUp(1))
        {
            freeLookComponent.m_XAxis.m_MaxSpeed = 0;
        }        
        if (Input.mouseScrollDelta.y !=0)
        {
            freeLookComponent.m_YAxis.m_MaxSpeed = 50;
        }

    }
}
