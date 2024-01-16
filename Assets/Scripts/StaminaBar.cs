using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public float stamina;
    public float maxStamina;

    public Slider staminaBar;
    public float dValue;


    // Start is called before the first frame update
    void Start()
    {
        stamina = maxStamina;
        staminaBar.maxValue = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            DecreaseStamina();
        else if (stamina != maxStamina)
            IncreaseStamina();

        staminaBar.value = stamina;

        if (stamina > maxStamina)
            stamina = maxStamina;

        if (stamina < 0)
            stamina = 0;
    }

    private void DecreaseStamina()
    {
        if (stamina != 0)
            stamina -= dValue * Time.deltaTime;
    }

    private void IncreaseStamina()
    {
        stamina += dValue * Time.deltaTime;
    }
}
