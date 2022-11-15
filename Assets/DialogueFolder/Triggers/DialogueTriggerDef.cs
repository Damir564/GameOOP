using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerDef : MonoBehaviour
{
    public Dialogue dialogue;
    public void TriggerDialogueDef()
    {
        FindObjectOfType<DialogueManagerDef>().StartDialogue(dialogue);
    }
}
