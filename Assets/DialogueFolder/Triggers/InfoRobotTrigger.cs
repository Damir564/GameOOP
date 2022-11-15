using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoRobotTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue dialogue1;
    public int step1 = 0;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Robot" && step1 == 0)
        {
            FindObjectOfType<DialogueManagerDef>().StartDialogue(dialogue);
            step1++;
            Debug.Log(step1);
        }

        else if (col.gameObject.tag == "Robot" && step1 == 1)
        {
            FindObjectOfType<DialogueManagerDef>().StartDialogue(dialogue1);
            step1++;
            Debug.Log(step1);
        }
    }
}