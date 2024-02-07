using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    private Queue<string> sentences = new();


    private void Update()
    {
        Find();
        if (Input.GetMouseButtonDown(0))
        {
            DisplayNextSentence();
        }
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

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

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


    public void Find()
    {
        if (nameText == null)
        {
            var obj = GameObject.FindWithTag("Name");
            if (obj != null)
            {
                nameText = obj.GetComponent<TextMeshProUGUI>();
            }

        }
        if (dialogueText == null)
        {
            var ef = GameObject.FindWithTag("Dialogue");
            if (ef != null)
            {
                dialogueText = ef.GetComponent<TextMeshProUGUI>();
            }
        }
    }


    void EndDialogue()
    {
        GameManager.instance.state = GameManager.State.playing;
        WaveHandler.startOfWave = true;
    }
}
