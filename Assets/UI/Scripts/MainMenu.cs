using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    float time = 4f;
    bool startTime;

    void Update()
    {
        if(startTime && time > 0)
        {
            time -= Time.deltaTime;
        }
        if(time < 0)
        {
            startTime = false;
            SceneManager.LoadScene("SotHM (final)");
            time = 0;
        }
    }
   public void PlayGame()
    {
        startTime = true;
    }

    void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
}
