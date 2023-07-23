using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private string currentScene = "GameScene";
    private string mainMenu = "MainMenu";

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMenu();
        }

    }

    public void ReturnToMenu()
    {
        SceneManager.UnloadScene(currentScene);
        SceneManager.LoadScene(mainMenu);
    }


}
