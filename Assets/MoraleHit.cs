using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoraleHit : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter()
    {
        player.GetComponent<PlayerStats>().changeMorale(-20); ;
    }
}
