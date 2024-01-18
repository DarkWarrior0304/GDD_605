using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

    [SerializeField] int currentWeapon = 0;

    private UIManager UIManager;
    Weapon wp;

    // Start is called before the first frame update
    void Start()
    {
        UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        wp = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        SetWeapomActive();
        ProcessScrollWheelInput();
    }

    private void ProcessScrollWheelInput()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            
            if(currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
                //UIManager.UpdateAmmo(currentAmmo);
            }
        }

        if(Input.GetAxis("Mouse ScrollWhell") < 0)
        {
            if(currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon --;
                //UIManager.UpdateAmmo(currentAmmo);
            }
        }
    }

    private void SetWeapomActive()
    {
        int weaponIndex = 0;

        foreach(Transform weapon in transform)
        {
            if(weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }

            else if(weaponIndex != currentWeapon)
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}
