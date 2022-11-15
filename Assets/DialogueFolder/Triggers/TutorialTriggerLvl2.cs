using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTriggerLvl2 : MonoBehaviour
{
    public Dialogue dialogue;

    public int step1;

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" && step1 == 0)
        {
            FindObjectOfType<DialogueManagerDef>().StartDialogue(dialogue);
            step1++;
            Debug.Log("d1" + step1);
        }

    }




}
