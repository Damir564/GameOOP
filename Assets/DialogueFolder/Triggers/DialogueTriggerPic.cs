using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerPic : MonoBehaviour
{
    public Dialogue dialogue;
    public void TriggerDialoguePic()
    {
        FindObjectOfType<DialogueManagerPic>().StartDialogue(dialogue);
    }
}
