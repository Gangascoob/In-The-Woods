using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BedSleep : MonoBehaviour, IInteractable
{

    private float _fadeDuration = 3.0f;

    [SerializeField] private GameObject _fadePanel;

    private Image _fade;
    
    // Start is called before the first frame update
    void Start()
    {
        _fade = _fadePanel.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Debug.Log("SLEEP");
        StartCoroutine(GameWin());
    }

    private IEnumerator GameWin()
    {
        //yield return null;


        Color currentColor = _fade.color;
        Color targetColor = Color.black;

        float timer = 0f;

        while (timer < _fadeDuration)
        {
            timer += Time.deltaTime;
            float t = timer / _fadeDuration;

            _fade.color = Color.Lerp(currentColor, targetColor, t);

            yield return null;
        }

        _fade.color = targetColor;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("WinScene");
    }
}
