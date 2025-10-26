using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quitApp()
    {
        Console.Out.WriteLine("Quit Application");
        Application.Quit();
    }

    public void playGame()
    {
        SceneManager.LoadScene("Assets/Scenes/SampleScene.unity");
    }

    public void toMenu()
    {
        SceneManager.LoadScene("Assets/Scenes/Menu.unity");
    }

    public void toSettings()
    {
        SceneManager.LoadScene("Assets/Scenes/Settings.unity");
    }
}
