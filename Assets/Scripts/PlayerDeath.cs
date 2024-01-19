using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject playerDeathUI;
    [SerializeField] bool lockCursor = true;


    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Enemy")
        {
            Debug.Log("YOU DIED");
            
            if (lockCursor)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            
            SceneManager.LoadScene("You Lose");
        }
    }
}
