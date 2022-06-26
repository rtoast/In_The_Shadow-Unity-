using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateVertical : MonoBehaviour
{
    public Transform Target;
    public GameObject CloseLevel;
    public GameObject retry;
    public GameObject back;
    public GameObject text;
    float toler = 10f;
    int Pos;

    void Update () {
         Vector3 mousePos = Input.mousePosition ;

        float angleRight = Quaternion.Angle(transform.rotation, Target.rotation);
        if (angleRight > toler){
            Pos = MousePos(mousePos);
            rotate(this.transform, Pos);
        }
        else{
            CloseLevelfunk();
        }

    }

    void rotate(Transform obj, int pos){
        if((Input.GetMouseButton(0))){
            if((Pos == 1))
                obj.transform.Rotate(0, 0.5f, 0, Space.World);                                       
            if((Pos == 2))
                obj.transform.Rotate(0, -0.5f, 0, Space.World);
            if((Pos == 3))
                obj.transform.Rotate(0.5f, 0, 0, Space.World);                                    
            if((Pos == 4))
                obj.transform.Rotate(-0.5f, 0, 0, Space.World);
        }
    }

    int MousePos(Vector3 mousePos){
        // Debug.Log(mousePos.y);
        if((mousePos.x < 1100) && ((mousePos.y > 1300) && (mousePos.y < 1900))){
            // Debug.Log(1);
            return(1);
        }
        if((mousePos.x > 1100) && ((mousePos.y > 1300) && (mousePos.y < 1900))){
            // Debug.Log(2);
            return(2);
        }
        if(mousePos.y < 1200){
            // Debug.Log(4);
            return(4);
        }
        if(mousePos.y > 1400){
            // Debug.Log(3);
            return(3);
        }
        return(0);
    }

    void CloseLevelfunk(){
        int i;
        int test;
        test = PlayerPrefs.GetInt("test");
        i = PlayerPrefs.GetInt("levelcomplite");
        if (i < 4 && test == 0)
            PlayerPrefs.SetInt("levelcomplite", 4);
        CloseLevel.SetActive(true);
        PlayerPrefs.SetInt("firstload", 0);

        retry.SetActive(true);
        text.SetActive(true);
        back.SetActive(false);
    }
}
