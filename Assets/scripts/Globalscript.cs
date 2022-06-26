using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globalscript : MonoBehaviour
{
    public static Globalscript Instance;
    public int levelcomplite;
    
    // public int start = 0;s
    void Awake (){
        if (Instance == null){
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this){
            Destroy (gameObject);
        }
    }

    void Update(){
        levelcomplite = PlayerPrefs.GetInt("levelcomplite");
        // Debug.Log("current level = " + levelcomplite);
    }
}
