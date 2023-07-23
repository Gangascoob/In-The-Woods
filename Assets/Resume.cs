using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{

    [SerializeField] private GameObject _menu;
    private bool isMenuOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isMenuOpen == false)
            {
                OpenMenu();
            }
            else if(isMenuOpen == true)
            {
                CloseMenu();
            }
            
        }
    }

    public void CloseMenu()
    {
        _menu.SetActive(false);
    }

    public void OpenMenu()
    {
        _menu.SetActive(true);
    }

}
