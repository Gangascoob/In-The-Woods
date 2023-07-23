using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private AudioClip _torchClick;
    [SerializeField] private GameObject _torch;
    [SerializeField] private GameObject _map;

    private AudioSource audioSource;

    private bool _isTorchOn = true;
    private bool _isMapOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(_isMapOpen == false)
            {
                _map.SetActive(true);
                _isMapOpen = true;
            }
            else
            {
                _map.SetActive(false);
                _isMapOpen = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            audioSource.PlayOneShot(_torchClick);

            if(_isTorchOn == false)
            {
                _torch.SetActive(true);
                _isTorchOn = true;
            }
            else
            {
                _torch.SetActive(false);
                _isTorchOn = false;
            }
        }
    }
}
