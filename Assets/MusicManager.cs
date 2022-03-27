using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource audioSource;
    public ObjectiveManager objManager;
    List<Objective> activeObjectives;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            audioSource.Play();

            activeObjectives = new List<Objective>(objManager.activeObjectives);
            foreach(Objective ob in activeObjectives){
                if(ob.objectiveID == 2)
                {
                    objManager.removeObjective(2);
                }
            }

        }
    }
}
