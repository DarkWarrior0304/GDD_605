using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    public GameObject ON;
    public GameObject OFF;

    public float battery;
    public float maxBattery;

    public float batteries = 0;

    public Slider batteryLife;
    public float dValue;
    private bool isON;

    [Header("Keybinds")]
    public KeyCode flashlight = KeyCode.F;
    public KeyCode batteryRefill = KeyCode.Q;

    // Start is called before the first frame update
    void Start()
    {
        battery = maxBattery;
        batteryLife.maxValue = maxBattery;
        ON.SetActive(false);
        OFF.SetActive(true);
        isON = false;
    }

    // Update is called once per frame
    void Update()
    {
        batteryLife.value = battery;

        if(Input.GetKeyDown(flashlight) && battery > 0)
        {
            if (isON)
            {
                ON.SetActive(false);
                OFF.SetActive(true);
            }

            if(!isON)
            {
                ON.SetActive(true);
                OFF.SetActive(false);
            }



            isON = !isON;
        }

        if(isON == true)
        {
            DecreaseBattery();
        }

        if(battery <= 0)
        {
            isON = false;
            ON.SetActive(false);
            OFF.SetActive(true);
            battery = 0;
        }

        if(battery >= maxBattery)
        {
            battery = maxBattery;
        }

        if(Input.GetKeyDown(batteryRefill) && batteries >=1)
        {
            batteries -= 1;
            battery += 90;
        }

        if (Input.GetKeyDown(batteryRefill) && batteries == 0)
        {
            return;
        }

        if(batteries <= 0)
        {
            batteries = 0;
        }
    }

    private void DecreaseBattery()
    {
        if (battery != 0)
            battery -= dValue * Time.deltaTime;
        
        
    }
}
