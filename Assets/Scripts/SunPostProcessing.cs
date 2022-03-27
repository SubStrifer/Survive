using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SunPostProcessing : MonoBehaviour
{
    public AnimationCurve curve;
    public Volume volume;
    TimeController _time;

    void Start()
    {
        _time = GetComponent<TimeController>();
    }

    // Update is called once per frame
    void Update()
    {
        volume.weight = curve.Evaluate((_time.currentTime.Hour * 60f + (float)_time.currentTime.Minute) / 1440f);
    }
}
