using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Play : MonoBehaviour
{
    [SerializeField] private GameObject _credits;

    [SerializeField] private string mainSceneName = "GameScene";
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private TextMeshProUGUI _almostThere;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        _credits.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadMainSceneAsync());

    }

    private IEnumerator LoadMainSceneAsync()
    {
        yield return new WaitForSeconds(1.0f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(mainSceneName);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                _almostThere.gameObject.SetActive(true);
                yield return new WaitForSeconds(1.0f);
                asyncLoad.allowSceneActivation = true;
            }
        }

        yield return null;
    }

}
