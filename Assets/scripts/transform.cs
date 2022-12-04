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
    public int levl;
    public float tolerDistance;
    public float tolerRotate;
    private int i = 1;
    private bool canMove;
    private bool flag = false;

    private void Start() {
        Cursor.visible = false;
    }
    void Update () {
        bool tol = tolerance();
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
        if (tol && flag == false){
            CloseLevelfunk();
        }
        else if(flag == false){
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
            }

            if ((i == 1) && canMove)
                Move(Two);
            if((i == 2)  && canMove)
                Move(Four);
            if (!canMove && i == 1)
                Rotate(Two);
            if (!canMove && i == 2)
                Rotate(Four);
        }
    }

    bool tolerance(){
        float angleFour = Quaternion.Angle(Four.transform.rotation, TargetFour.rotation);
        float angleTwo = Quaternion.Angle(Two.transform.rotation, TargetTwo.rotation);
        float distanceFour = Vector3.Distance(Two.transform.position, Four.transform.position);
        bool rot = false;
        if (angleFour < tolerRotate && angleTwo < tolerRotate)
            rot = true;
        if (rot && (distanceFour < tolerDistance)){
            return(true);
        }
        return(false);
    }

    void Rotate(Transform obj){
        if((Input.GetMouseButton(0))){
            obj.transform.eulerAngles = new Vector3(obj.transform.eulerAngles.x, 
                obj.transform.eulerAngles.y - Input.GetAxis("Mouse X") * 5f, 
                obj.transform.eulerAngles.z + Input.GetAxis("Mouse Y") * 5f);
        }
    }

    void Move(Transform obj){
        if ((Input.GetMouseButton(0)))
            obj.transform.position = obj.transform.position + new Vector3(Input.GetAxis("Mouse X") * 100f * Time.deltaTime, Input.GetAxis("Mouse Y") * 100f * Time.deltaTime, 0);
    }
    void Pause()
    {
        if (!CloseLevel.activeSelf)
        {
            if (flag == false)
                flag = true;
            else
                flag = false;
            Cursor.visible = flag;
            retry.SetActive(flag);
            back.SetActive(flag);
        }
    }

    void CloseLevelfunk(){
        int i;
        int test;
        test = PlayerPrefs.GetInt("test");
        i = PlayerPrefs.GetInt("levelcomplite");
        if (i < levl && test == 0)
            PlayerPrefs.SetInt("levelcomplite", levl);
        PlayerPrefs.SetInt("firstload", 0);
        CloseLevel.SetActive(true);
        retry.SetActive(true);
        text.SetActive(true);
        back.SetActive(false);
        Cursor.visible = true;
    }
}
