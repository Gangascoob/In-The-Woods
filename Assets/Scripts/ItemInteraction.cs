using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemInteraction : MonoBehaviour
{

    private float interactionDistance = 5f;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private TextMeshProUGUI _text;
    private bool textActive = false;

    // Start is called before the first frame update
    void Start()
    {
       // mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }

        RaycastHit hittwo;
        Ray raytwo = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(raytwo, out hittwo, interactionDistance))
        {
            IInteractable interactabletwo = hittwo.collider.GetComponent<IInteractable>();
            if(interactabletwo != null)
            {
                ShowText();
                textActive = true;

            }
            else if (textActive == true)
            {
                HideText();
                textActive = false;
            }
        }

    }

    private void ShowText()
    {
        _text.gameObject.SetActive(true);
    }

    private void HideText()
    {
        _text.gameObject.SetActive(false);
    }
}
