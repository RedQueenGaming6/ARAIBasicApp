using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManagement : MonoBehaviour
{
    // This method is responsible for exiting the application.
    // It uses Unity's Application.Quit() function to terminate the application.
    public void ExitApplication()
    {
        Application.Quit();
    }

    // This method is used to change the current scene in the Unity application.
    // It takes a string parameter 'scene', representing the name of the scene to be loaded.
    // It uses Unity's SceneManager.LoadScene() function to load the specified scene.

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
