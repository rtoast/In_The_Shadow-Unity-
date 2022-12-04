using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
	public void Reset(){
        PlayerPrefs.SetInt("levelcomplite", 0);
        PlayerPrefs.SetInt("firstload", 0);
    }

    public void Play()
	{
		SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("test", 0);
	}

    public void Test()
	{
		SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("test", 1);
	}

    public void Setting()
    {
	    SceneManager.LoadScene("SettingMenu");
    }
    public void Exit()
	{
        // Debug.Log("Exit pressed!");
		Application.Quit();
	}
}
