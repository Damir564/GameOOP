using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TutorialBuildingsTrigger : MonoBehaviour, IPointerDownHandler
{
    public Dialogue dialogue;
    public int step1;

    // Start is called before the first frame update
    public void OnPointerDown(PointerEventData e)
    {
        if (step1 == 0)
        {
            FindObjectOfType<DialogueManagerDef>().StartDialogue(dialogue);
            step1++;
        }
    }
}