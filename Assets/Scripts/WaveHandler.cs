using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    public static int WaveNumber = 0;

    public List<GameObject> allCanvases;

    public Dialogue dialogue;



    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void Start()
    {
        
    }




    private void Dialogue()
    {

    }

    void Update()
    {
        TriggerDialogue();
    }
}
