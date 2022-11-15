using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;

    public Text firstAnswer;
    public Text secondAnswer;
    public Text thirdAnswer;
    public Text fourthAnswer;
    public Text fifthAnswer;
    public Text sixthAnswer;
    public Text seventhAnswer;
    public Text eighthAnswer;
    public Text ninethAnswer;
    public Text tenthAnswer;
    public Text eleventhAnswer;
    public Text twelvethAnswer;

    public GameObject dialogueUI;

    public Text firstSentence;
    public Text secondSentence;
    public Text thirdSentence;
    public Text fourthSentence;
    public Text fifthSentence;
    public Text sixthSentence;
    public Text seventhSentence;
    public Text eighthSentence;
    public Text ninethSentence;
    public Text tenthSentence;
    public Text eleventhSentence;
    public Text twelvethSentence;
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
        fourthSentence.text = dialoguevar.sentences[4];
        fifthSentence.text = dialoguevar.sentences[5];
        sixthSentence.text = dialoguevar.sentences[6];
        seventhSentence.text = dialoguevar.sentences[7];
        eighthSentence.text = dialoguevar.sentences[8];
        ninethSentence.text = dialoguevar.sentences[9];
        tenthSentence.text = dialoguevar.sentences[10];
        eleventhSentence.text = dialoguevar.sentences[11];
        twelvethSentence.text = dialoguevar.sentences[12];
        firstAnswer.text = dialoguevar.answers[0];
        secondAnswer.text = dialoguevar.answers[1];
        thirdAnswer.text = dialoguevar.answers[2];
        fourthAnswer.text = dialoguevar.answers[3];
        fifthAnswer.text = dialoguevar.answers[4];
        sixthAnswer.text = dialoguevar.answers[5];
        seventhAnswer.text = dialoguevar.answers[6];
        eighthAnswer.text = dialoguevar.answers[7];
        ninethAnswer.text = dialoguevar.answers[8];
        tenthAnswer.text = dialoguevar.answers[9];
        eleventhAnswer.text = dialoguevar.answers[10];
        twelvethAnswer.text = dialoguevar.answers[11];

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

    public void FourthAnswer()
    {
        dialogueText.text = fourthSentence.text;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(fourthSentence.text));
    }


    public void FifthAnswer()
    {
        dialogueText.text = fifthSentence.text;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(fifthSentence.text));
    }

    public void SixthAnswer()
    {
        dialogueText.text = sixthSentence.text;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sixthSentence.text));
    }

    public void SeventhAnswer()
    {
        dialogueText.text = seventhSentence.text;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(seventhSentence.text));
    }


    public void EighthAnswer()
    {
        dialogueText.text = eighthSentence.text;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(eighthSentence.text));
    }

    public void NinethAnswer()
    {
        dialogueText.text = ninethSentence.text;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(ninethSentence.text));
    }

    public void TenthAnswer()
    {
        dialogueText.text = tenthSentence.text;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(tenthSentence.text));
    }


    public void EleventhAnswer()
    {
        dialogueText.text = eleventhSentence.text;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(eleventhSentence.text));
    }

    public void TwelvethAnswer()
    {
        dialogueText.text = twelvethSentence.text;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(twelvethSentence.text));
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
