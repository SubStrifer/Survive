using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDialogue : MonoBehaviour
{

    public DialogueManager dialogueManager;
    public Dialogue dialogue;
    public Objective objective;

    void OnTriggerEnter()
    {
        dialogueManager.StartDialogue(dialogue, objective);
    }

    void OnTriggerExit()
    {
        gameObject.SetActive(false);
    }

}
