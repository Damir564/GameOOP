using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonTrigger : MonoBehaviour
{
    public GameObject wall;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Robot")
        {
            gameObject.transform.localScale = new Vector3(2f, 0.05f, 2f);
            wall.SetActive(false);
        }    

    }
}
