using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnStart : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue dialogue1;
    public DialogueVar dialoguevar;
    public int step1 = 0;
    public void Update()
    {
        if (step1 == 0)
        {
            //Thread.Sleep(10000);
            FindObjectOfType<DialogueManagerPic>().StartDialogue(dialogue);
            step1++;
            //Debug.Log (step1);
        }
        else if (step1 == 1)
        {
            //Thread.Sleep(10000);
            FindObjectOfType<DialogueManagerDef>().StartDialogue(dialogue1);
            step1++;
            //Debug.Log (step1);
        }
        else if (step1 == 2)
        {
            //Thread.Sleep(10000);
            FindObjectOfType<DialogueManagerVar>().StartDialogueVar(dialoguevar);
            step1++;
            //Debug.Log (step1);
        }
    }
}
