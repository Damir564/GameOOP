using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public int step1;

    // Start is called before the first frame update
    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && step1 == 0)
        {
            FindObjectOfType<DialogueManagerDef>().StartDialogue(dialogue);
            step1++;
        }
    }

}