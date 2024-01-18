using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    private bool inReach;

    public GameObject pickUpText;
    private GameObject flashlight;

    [Header("Keybinds")]
    public KeyCode interact = KeyCode.E;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        flashlight = GameObject.Find("flashlight");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(interact) && inReach)
        {
            flashlight.GetComponent<Flashlight>().batteries += 1;
            inReach = false;
            pickUpText.SetActive(false);
            Destroy(gameObject);
        }
    }
}
