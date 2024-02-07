using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    public static int WaveNumber = 0;

    public List<GameObject> allCanvases;

    public Dialogue dialogue;

    public static bool endOfWave = true;
    public GameObject canvas;
    public DialogueManager dialoguemanager;
    public static bool startOfWave = false;

    public void TriggerDialogue()
    {
        dialoguemanager.Find();
        dialoguemanager.StartDialogue(dialogue);
    }

    private void WaveStarter()
    {
        if (startOfWave)
        {
            startOfWave = false;
            canvas.transform.GetChild(0).gameObject.SetActive(false);
        }
    }


    void Update()
    {
        WaveStarter();
        if (endOfWave)
        {
            canvas.transform.GetChild(0).gameObject.SetActive(true);
            TriggerDialogue();
            endOfWave = false;
        }
    }
}
