using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    Queue<string> dialogueSentences;
    public ObjectiveManager objManager;
    Objective objective;
    public GameObject dialogueBox;

    void Start()
    {
        dialogueSentences = new Queue<string>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            nextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue, Objective obj){
        
        dialogueBox.SetActive(true);
        objective = obj;

        foreach(string sentence in dialogue.sentences)
        {
            dialogueSentences.Enqueue(sentence);
        }
        
        nextSentence();
    }

    void nextSentence(){

        if (dialogueSentences.Count==0){
            closeDialogue();
            return;
        } 

        dialogueText.text = dialogueSentences.Dequeue();

    }

    void closeDialogue(){
        //Disable dialogue box
        dialogueBox.SetActive(false);

        if (objective.title == "DELETE")
        {
            objManager.removeObjective(objective.objectiveID);
        } else {
            objManager.addObjective(objective);
        }
        
    }

}