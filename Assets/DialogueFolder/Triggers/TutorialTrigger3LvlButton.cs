using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger3LvlButton : MonoBehaviour
{
    public Dialogue dialogue;

    public int step1;

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Robot" && step1 == 0)
        {
            FindObjectOfType<DialogueManagerDef>().StartDialogue(dialogue);
            step1++;
            Debug.Log("d1" + step1);
        }

    }




}