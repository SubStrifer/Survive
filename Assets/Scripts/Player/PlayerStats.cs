using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public float healthmax;
    public float foodmax;
    public float watermax;
    public float moralemax;

    public Slider healthbar;
    public Slider moralebar;
    public Slider waterbar;
    public Slider foodbar;

    public TimeController time;
    private double temperature;

    public int statstick;

    private bool stressed = false;

    // Start is called before the first frame update
    void Start()
    {
        healthbar.maxValue = healthmax;
        healthbar.value = healthmax;

        foodbar.maxValue = foodmax;
        foodbar.value = foodmax;

        waterbar.maxValue = watermax;
        waterbar.value = watermax;

        moralebar.maxValue = moralemax;
        moralebar.value = moralemax;

        StartCoroutine(StatModifier());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeHealth(int value)
    {
        healthbar.value += value;
    }

    public void changeWater(int value)
    {
        waterbar.value += value;
    }

    public void changeFood(int value)
    {
        foodbar.value += value;
    }

    public void changeMorale(int value)
    {
        moralebar.value += value;
    }

    public void stressTrigger()
    {
        stressed = true;
    }

    public void calmTrigger()
    {
        stressed = false;
    }

    IEnumerator StatModifier()
    {
        while (true)
        {
            yield return new WaitForSeconds(statstick);
            temperature = time.getTemperature();
            if(temperature > 50)
            {
                changeWater(-5);
            }
            else
            {
                changeWater(-1);
            }

            changeFood(-1);

            if (stressed)
            {
                changeMorale(-5);
            }
            else
            {
                changeMorale(-1);
            }
            

        }

    }
}
