using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public Transform targetRigth;
    public Transform targetLeft;
    public GameObject BackCloseLevel;
    public GameObject Retry;
    public GameObject Back;
    public GameObject Text;
    float tolerance = 1f;
    // playmode mode;

    void Update () {
         Vector3 mousePos = Input.mousePosition ;

        float angleRight = Quaternion.Angle(transform.rotation, targetRigth.rotation);
        float angleLeft = Quaternion.Angle(transform.rotation, targetLeft.rotation);
        if (angleRight > tolerance && angleLeft > tolerance){
            if(Input.GetMouseButton(0) && (mousePos.x < 1000)){
                this.transform.Rotate(0, 0.5f, 0, Space.World);
            }                                       
            if(Input.GetMouseButton(0) && (mousePos.x > 1000)){
                this.transform.Rotate(0, -0.5f, 0, Space.World);
            }
        }
        else{
            CloseLevelfunk();
        }
    }

    void CloseLevelfunk(){
        int i;
        int test;
        test = PlayerPrefs.GetInt("test");
        i = PlayerPrefs.GetInt("levelcomplite");
        if (i < 2 && test == 0)
            PlayerPrefs.SetInt("levelcomplite", 2);
        PlayerPrefs.SetInt("firstload", 0);
        BackCloseLevel.SetActive(true);
        Retry.SetActive(true);
        Text.SetActive(true);
        Back.SetActive(false);
    }
}
