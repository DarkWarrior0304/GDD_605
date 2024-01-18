using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text ammoText;

    [SerializeField]
    private Text magText;
    public void UpdateAmmo(float count)
    {
        ammoText.text = "/ " + count;
    }

    public void UpdateMag(float count)
    {
        magText.text = " " + count;
    }
}
