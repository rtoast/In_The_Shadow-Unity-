using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playmode : MonoBehaviour
{
    public GameObject levelTwo;
    public GameObject levelFive;
    public GameObject levelThree;
    public GameObject levelFour;
    public GameObject textTwo;
    public GameObject textThree;
    public GameObject textFour;
    public GameObject textFive;
    int level;
    int test;

    void Start(){


        level = PlayerPrefs.GetInt("levelcomplite");
        test = PlayerPrefs.GetInt("test");

        if (test == 0){
            switch (level){
                case 0:
                    if (PlayerPrefs.GetInt("firstload") == 1 )
                        break;

                    levelTwo.SetActive(true);
                    levelThree.SetActive(true);
                    levelFour.SetActive(true);
                    levelFive.SetActive(true);
                    ButtonAnimation(levelTwo, false, textTwo);
                    ButtonAnimation(levelThree, false, textThree);
                    ButtonAnimation(levelFour, false, textFour);
                    ButtonAnimation(levelFive, false, textFive);
                    PlayerPrefs.SetInt("firstload", 1);
                    break;
                case 2:
                    if (PlayerPrefs.GetInt("firstload") == 1 ){
                     levelTwo.SetActive(true);
                        break;
                    }
                    ButtonAnimation(levelTwo, true, textTwo);
                    levelThree.SetActive(false);
                    levelFour.SetActive(false);
                    PlayerPrefs.SetInt("firstload", 1);
                    break;
                case 3:
                 if (PlayerPrefs.GetInt("firstload") == 1 ){
                     levelThree.SetActive(true);
                     levelTwo.SetActive(true);
                        break;
                    }
                    levelTwo.SetActive(true);
                    ButtonAnimation(levelThree, true, textThree);
                    levelFour.SetActive(false);
                    PlayerPrefs.SetInt("firstload", 1);
                    break;
                case 4:
                 if (PlayerPrefs.GetInt("firstload") == 1 ){
                     levelFour.SetActive(true);
                      levelThree.SetActive(true);
                     levelTwo.SetActive(true);
                        break;
                    }
                    levelTwo.SetActive(true);
                    levelThree.SetActive(true);
                    ButtonAnimation(levelFour, true, textFour);
                    PlayerPrefs.SetInt("firstload", 1);
                    break;
                case 5:
                    if (PlayerPrefs.GetInt("firstload") == 1 ){
                        levelFive.SetActive(true);
                        levelFour.SetActive(true);
                        levelThree.SetActive(true);
                        levelTwo.SetActive(true);
                        break;
                    }
                    levelFour.SetActive(true);
                    levelTwo.SetActive(true);
                    levelThree.SetActive(true);
                    ButtonAnimation(levelFive, true, textFive);
                    PlayerPrefs.SetInt("firstload", 1);
                    break;
                case 6:
                    levelFive.SetActive(true);
                    levelFour.SetActive(true);
                    levelThree.SetActive(true);
                    levelTwo.SetActive(true);
                    break;
            }
        }
        else{
            PlayerPrefs.SetInt("test", 1);
            levelTwo.SetActive(true);
            levelThree.SetActive(true);
            levelFour.SetActive(true);
            levelFive.SetActive(true);
        }
    }

    void ButtonAnimation(GameObject but, bool bright, GameObject tex)
    {
        Image button = but.GetComponent<Image>();
        Text text = tex.GetComponent<Text>();

        if (bright)
            StartCoroutine(corTrue(button, but, text));
        else
            StartCoroutine(corFalse(button, but, text));
    }

    IEnumerator corTrue(Image image, GameObject but, Text text)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        but.SetActive(true);

        while (image.color.a < 1 && text.color.a < 1)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + 0.01f);
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator corFalse(Image image, GameObject but, Text text)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);

        while (image.color.a > 0 && text.color.a > 0)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - 0.01f);
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        but.SetActive(false);
    }
}
