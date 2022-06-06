using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Back()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene(0);
	}

    public void ChooseScene(int a)                  
    {
        // DontDestroyOnLoad(this);
        // Destroy(this);
        SceneManager.LoadScene(a);              
    }
}
