using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerVar : MonoBehaviour
{
    public DialogueVar dialoguevar;
    public void TriggerDialogueVar()
    {
        FindObjectOfType<DialogueManagerVar>().StartDialogueVar(dialoguevar);
    }
    
}
