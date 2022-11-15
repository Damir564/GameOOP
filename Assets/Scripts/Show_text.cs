using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_text : MonoBehaviour
{
    public GameObject showText;
    public float showDistance = 4f;
    public Transform fromTheObject;
    

    private void OnMouseOver()
    {
        if (fromTheObject)
        {
           Vector3 offset = fromTheObject.position - transform.position;
           float sqrLen = offset.sqrMagnitude;
            if (sqrLen < (showDistance * showDistance))
                showText.SetActive(true);
        }
    }


    private void OnMouseExit()
    {
        showText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (fromTheObject)
        {
            Vector3 offset = fromTheObject.position - transform.position;
            float sqrLen = offset.sqrMagnitude;
            if (sqrLen > showDistance * showDistance)
                showText.SetActive(false);
        }
    }
}
