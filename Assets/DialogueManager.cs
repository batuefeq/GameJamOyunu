using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    private Queue<string> sentences;

    void Awake()
    {
        sentences = new Queue<string>();
        Find();
    }


    private void Update()
    {

        DisplayNextSentence();
    }


    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        } 
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


    private void Find()
    {
        if (nameText == null)
        {
            var obj = GameObject.FindWithTag("Name");
            nameText = obj.GetComponent<TextMeshProUGUI>();


        }
        if (dialogueText == null)
        {
            var ef = GameObject.FindWithTag("Dialogue");
            dialogueText = ef.GetComponent<TextMeshProUGUI>();
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of conv");
    }

}
