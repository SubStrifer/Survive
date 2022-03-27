using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDialogue : MonoBehaviour
{

    public DialogueManager dialogueManager;
    public Dialogue dialogue;
    public Objective newObjective;
    public int oldObjectiveID;

    void OnTriggerEnter()
    {
        dialogueManager.StartDialogue(dialogue, newObjective, oldObjectiveID);
    }

    void OnTriggerExit()
    {
        gameObject.SetActive(false);
    }

}
