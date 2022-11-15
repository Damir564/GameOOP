using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialRobotTrigger : MonoBehaviour
{
    public Dialogue dialogue;
   
    public int step1;

    void OnTriggerEnter(Collider col)
    {
        int a = 0;
        if (col.gameObject.tag == "Robot" && step1 == 0)
        {
            FindObjectOfType<DialogueManagerDef>().StartDialogue(dialogue);
            step1++;
        }
    }

}
