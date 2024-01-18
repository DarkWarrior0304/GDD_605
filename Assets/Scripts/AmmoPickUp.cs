using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{

    private bool inReach;

    public GameObject pickUpText;
    private GameObject pistol;
    private GameObject rifle;
    private GameObject shotgun;

    [Header("Keybinds")]
    public KeyCode interact = KeyCode.E;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        pistol = GameObject.Find("Pistol");
        rifle = GameObject.Find("Rifle");
        shotgun = GameObject.Find("ShotGun");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(interact) && inReach)
        {
            pistol.GetComponent<Weapon>().currentAmmo = pistol.GetComponent<Weapon>().maxAmmo;
            rifle.GetComponent<Weapon>().currentAmmo = rifle.GetComponent<Weapon>().maxAmmo;
            shotgun.GetComponent<Weapon>().currentAmmo = shotgun.GetComponent<Weapon>().maxAmmo;
            inReach = false;
            pickUpText.SetActive(false);
            
        }
    }
}
