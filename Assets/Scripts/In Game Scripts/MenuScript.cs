using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    
    public void LoadLevel()
    {
        // Load the level named "demoLevel"
        SceneManager.LoadScene("demoLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
