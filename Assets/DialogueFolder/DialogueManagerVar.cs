using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerVar : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    
    public Text firstAnswer;
    public Text secondAnswer;
    public Text thirdAnswer;

    public GameObject dialogueUI;

    public Text firstSentence;
    public Text secondSentence;
    public Text thirdSentence;
    //private string[] sentences;
    // private Queue<string> sentences;
    //private string[2] answers;
    void Start()
    {
        //sentences.Clear();
        //dialogueUI.SetActive(false);
        //sentences = new Queue<string>();
    }
    public void StartDialogueVar(DialogueVar dialoguevar)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialoguevar.name;

        //dialogueUI.SetActive(true);
        
        dialogueText.text = dialoguevar.sentences[0];
        firstSentence.text = dialoguevar.sentences[1];
        secondSentence.text = dialoguevar.sentences[2];
        thirdSentence.text = dialoguevar.sentences[3];
        firstAnswer.text = dialoguevar.answers[0];
        secondAnswer.text = dialoguevar.answers[1];
        thirdAnswer.text = dialoguevar.answers[2];
        
    }


    public void FirstAnswer()
    {
        dialogueText.text = firstSentence.text;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(firstSentence.text));
    }
    

    public void SecondAnswer()
    {
        dialogueText.text = secondSentence.text;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(secondSentence.text));
    }

    public void ThirdAnswer()
    {
        dialogueText.text = thirdSentence.text;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(thirdSentence.text));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogueVar()
    {
        animator.SetBool("IsOpen", false);
        //dialogueUI.SetActive(false);
    }
}
