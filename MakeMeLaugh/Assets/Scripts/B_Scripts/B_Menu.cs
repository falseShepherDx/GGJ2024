using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B_Menu : MonoBehaviour
{
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void PlayGame()
    {
      
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
