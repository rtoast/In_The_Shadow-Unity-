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
        if((mousePos.x < 1108) && ((mousePos.y > 1100) && (mousePos.y < 1500)))
            return(1);
        if((mousePos.x > 1108) && ((mousePos.y > 1100) && (mousePos.y < 1500)))
            return(2);
        if(mousePos.y < 1200)
            return(3);
        if(mousePos.y > 1400)
            return(4);
        return(0);
    }

    void CloseLevelfunk(){
        CloseLevel.SetActive(true);
        retry.SetActive(true);
        text.SetActive(true);
        back.SetActive(false);
    }
}
