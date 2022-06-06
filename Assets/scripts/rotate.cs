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

    void Update () {
         Vector3 mousePos = Input.mousePosition ;

        float angleRight = Quaternion.Angle(transform.rotation, targetRigth.rotation);
        float angleLeft = Quaternion.Angle(transform.rotation, targetLeft.rotation);
        if (angleRight > tolerance && angleLeft > tolerance){
            if(Input.GetMouseButton(0) && (mousePos.x < 492)){
                this.transform.Rotate(0, 0.5f, 0, Space.World);
            }                                       
            if(Input.GetMouseButton(0) && (mousePos.x > 492)){
                this.transform.Rotate(0, -0.5f, 0, Space.World);
            }
        }
        else{
            CloseLevelfunk();
        }
    }

    void CloseLevelfunk(){
        BackCloseLevel.SetActive(true);
        Retry.SetActive(true);
        Text.SetActive(true);
        Back.SetActive(false);
    }
}
