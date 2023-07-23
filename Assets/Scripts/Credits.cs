using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Credits : MonoBehaviour
{
    [SerializeField] private GameObject _credits;
    private bool creditsOn = false;

    public void ToggleCredits()
    {
        if (creditsOn == false)
        {
            _credits.SetActive(true);
            creditsOn = true;
        }
        else if (creditsOn == true)
        {
            _credits.SetActive(false);
            creditsOn = false;
        }
    }
}
