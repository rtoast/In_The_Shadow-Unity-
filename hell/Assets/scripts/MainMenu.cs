using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void Play()
	{
		SceneManager.LoadScene("Level");
	}

    public void ChooseScene(int a)                  
    {
        // DontDestroyOnLoad(this);
        SceneManager.LoadScene(a);                  
    }
    public void Exit()
	{
        Debug.Log("Exit pressed!");
		Application.Quit();
	}
}
