using System;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    public float timeMultiplier;

    [SerializeField]
    private float startHour;

    [SerializeField]
    private TextMeshProUGUI timeText;

    [SerializeField]
    private TextMeshProUGUI tempValue;

    [SerializeField]
    private Light sunLightA;
    [SerializeField]
    private GameObject sunA;

    [SerializeField]
    private Light sunLightB;

    [SerializeField]
    private GameObject sunB;

    [SerializeField]
    private float sunriseAHour;

    [SerializeField]
    private float sunsetAHour;

    [SerializeField]
    private Color dayAmbientLight;

    [SerializeField]
    private Color nightAmbientLight;

    [SerializeField]
    private AnimationCurve lightChangeCurve;

    [SerializeField]
    private float maxSunLightAIntensity;

    [SerializeField]
    private float maxSunLightBIntensity;

    public DateTime currentTime;

    private int degrees;
    private TimeSpan sunriseATime;

    private TimeSpan sunsetATime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);
        sunriseATime = TimeSpan.FromHours(sunriseAHour);
        sunsetATime = TimeSpan.FromHours(sunsetAHour);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeOfDay();
        tempValue.text = degrees.ToString();
        RotateSunA();
        UpdateLightAndTemp();
    }

    private void UpdateTimeOfDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);

        if (timeText != null)
        {
            timeText.text = currentTime.ToString("HH:mm");
        }
    }

    private void RotateSunA()
    {
        float sunLightARotation;

        if (currentTime.TimeOfDay > sunriseATime && currentTime.TimeOfDay < sunsetATime)
        {
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseATime, sunsetATime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseATime, currentTime.TimeOfDay);

            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

            sunLightARotation = Mathf.Lerp(0, 180, (float)percentage);
        }
        else
        {
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(sunsetATime, sunriseATime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetATime, currentTime.TimeOfDay);

            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;

            sunLightARotation = Mathf.Lerp(180, 360, (float)percentage);
        }

        sunA.transform.rotation = Quaternion.AngleAxis(sunLightARotation, Vector3.right);
        sunB.transform.rotation = Quaternion.AngleAxis(sunLightARotation+20, Vector3.right);
    }

    private void UpdateLightAndTemp()
    {
        float dotProduct = Vector3.Dot(sunLightA.transform.forward, Vector3.down);
        sunLightA.intensity = Mathf.Lerp(0, maxSunLightAIntensity, lightChangeCurve.Evaluate(dotProduct));
        degrees = (int)((sunLightA.intensity/1.2*70) -10);
        sunLightB.intensity = Mathf.Lerp(0, maxSunLightBIntensity, lightChangeCurve.Evaluate(dotProduct));
        RenderSettings.ambientLight = Color.Lerp(nightAmbientLight, dayAmbientLight, lightChangeCurve.Evaluate(dotProduct));
    }
    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;

        if (difference.TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours(24);
        }

        return difference;
    }
}