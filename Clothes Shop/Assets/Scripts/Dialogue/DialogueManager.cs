using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject choisePanel;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Animator animator;
    
    public bool hasStarted = false;

    private Queue<string> sentences;
    
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        hasStarted = true;

        nameText.text = "";
        dialogueText.text = "";

        animator.SetBool("isShown", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Invoke(nameof(DisplayNextSentence), 0.4f);
    }

    public void DisplayNextSentence()
    {
        if (choisePanel.activeSelf) { return; }

        if (sentences.Count == 0)
        {
            StopAllCoroutines();
            dialogueText.text = "";
            nameText.text = "";
            choisePanel.SetActive(true);
            
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (Char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        choisePanel.SetActive(false);
        hasStarted = false;
        animator.SetBool("isShown", false);
    }
}
