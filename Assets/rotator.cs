using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    // Start is called before the first frame update
    public float D = 0.4f;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Rotate(0, D, 0);
    }
}
