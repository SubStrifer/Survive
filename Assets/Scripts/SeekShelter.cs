using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekShelter : MonoBehaviour
{
    [SerializeField]
    public GameObject TimeSlider;

    public void openTimeSlider()
    {
        TimeSlider.SetActive(true);
    }
}
