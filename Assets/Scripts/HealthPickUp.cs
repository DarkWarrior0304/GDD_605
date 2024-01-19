using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    private bool inReach;

    public GameObject pickUpText;
    private GameObject player;

    [Header("Keybinds")]
    public KeyCode interact = KeyCode.E;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        player = GameObject.Find("player");
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
            player.GetComponent<PlayerHealth>().currentHealth = player.GetComponent<PlayerHealth>().health;
            inReach = false;
            pickUpText.SetActive(false);

        }
    }
}
