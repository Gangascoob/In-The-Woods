using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{

    [SerializeField] private GameObject _menu;
    private bool isMenuOpen = false;

    [SerializeField] private GameObject camera1;
    [SerializeField] private GameObject camera2;

    private CameraController controller1;
    private CameraController controller2;

    // Start is called before the first frame update
    void Start()
    {
        controller1 = camera1.GetComponent<CameraController>();
        controller2 = camera2.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isMenuOpen == false)
            {
                OpenMenu();
                controller1.enabled = false;
                controller2.enabled = false;
            }
            else if(isMenuOpen == true)
            {
                CloseMenu();
                controller1.enabled = true;
                controller2.enabled = true;
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
