using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transform : MonoBehaviour
{
    public Transform Four;
    public Transform Two;
    public Transform TargetFour;
    public Transform TargetTwo;
    public GameObject CloseLevel;
    public GameObject retry;
    public GameObject back;
    public GameObject text;
    float toler = 10f;
    int i = 1;
    int Pos;
    bool canMove;

    void Update () {
        Vector3 mousePos = Input.mousePosition ;
        bool tol = tolerance();
        if (tol){
            CloseLevelfunk();
        }
        else{
            if ((Input.GetKeyUp(KeyCode.Space))){
                if (i == 2)
                    i = 1;
                else if (i == 1)
                    i = 2;
            }
            if(Input.GetKeyUp(KeyCode.Tab)){
                if (canMove == false)
                    canMove = true;
                else if(canMove == true)
                    canMove = false; 
                // Debug.Log(canMove);
            }
            if ((i == 1) && canMove){
                Pos = MousePos(mousePos);
                move(Two, Pos);
            }
            if((i == 2)  && canMove){
                Pos = MousePos(mousePos);
                move(Four, Pos);
            }
            if (!canMove && i == 1){
                Pos = MousePos(mousePos);
                rotate(Two, Pos);
            }
            if (!canMove && i == 2){
                Pos = MousePos(mousePos);
                rotate(Four, Pos);
            }
        }

    }

    bool tolerance(){
        float x = Four.rotation.x - TargetFour.rotation.x;
        float y = Four.rotation.y - TargetFour.rotation.y;
        float z = Four.rotation.z - TargetFour.rotation.z;
        float distanceFour = Vector3.Distance(Four.transform.position, TargetFour.position);
        float distanceTwo = Vector3.Distance(Two.transform.position, TargetTwo.position);
        bool rot = false;
        if (x < (toler * 2) && y < toler && z < toler)
            rot = true;
        if (rot && ((distanceFour < toler) && (distanceTwo < toler))){
            return(true);
        }
        return(false);
    }

    void rotate(Transform obj, int pos){
        if((Input.GetMouseButton(0))){
            if((Pos == 1))
                obj.transform.Rotate(0, 0.5f, 0, Space.World);                                   
            if((Pos == 2))
                obj.transform.Rotate(0, -0.5f, 0, Space.World);
            if((Pos == 3))
                obj.transform.Rotate(-0.5f, 0, 0, Space.World);                                       
            if((Pos == 4))
                obj.transform.Rotate(0.5f, 0, 0, Space.World);
        }
    }

    void move(Transform obj, int pos){
        if ((Input.GetMouseButton(0))){
            if(Pos == 1)
                obj.transform.Translate(-1,0,0,Space.World );                                      
            if(Pos == 2)
                obj.transform.Translate(1, 0, 0, Space.World);
            if(Pos == 3)
                obj.transform.Translate(0, -1, 0, Space.World);                                     
            if(Pos == 4)
                obj.transform.Translate(0, 1, 0, Space.World);
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
