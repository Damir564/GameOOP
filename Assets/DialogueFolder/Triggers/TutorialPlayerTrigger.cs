using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialPlayerTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue dialogue1;
    public int step1, step2;

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player" && step1 == 0)
        {
            FindObjectOfType<DialogueManagerDef>().StartDialogue(dialogue);
            step1++;
            Debug.Log("d1" + step1);
        }

    }

    public void OnTriggerStay(Collider other)
    {
       
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && step2 == 0)
        {
            FindObjectOfType<DialogueManagerDef>().StartDialogue(dialogue1);
            step2++;
            Debug.Log("d2" + step2);
        }

       

    }

}