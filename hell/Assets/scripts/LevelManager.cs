using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Back()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

    public void ChooseScene(int a)                  
    {
        // DontDestroyOnLoad(this);
        SceneManager.LoadScene(a);                  
    }
}
