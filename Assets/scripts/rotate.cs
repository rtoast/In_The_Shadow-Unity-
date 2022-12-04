using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotate : MonoBehaviour
{
    [Header("Options")] public Transform targetRigth;
    public Transform targetLeft;
    public GameObject BackCloseLevel;
    public GameObject Retry;
    public GameObject Back;
    public GameObject Text;
    public bool Vertical;
    public int levl;
    float tolerance = 1f;
    private bool flag = false;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        float angleRight = Quaternion.Angle(transform.rotation, targetRigth.rotation);
        float angleLeft = Quaternion.Angle(transform.rotation, targetLeft.rotation);
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
        if (angleRight > tolerance && angleLeft > tolerance && flag == false)
        {
            if (Input.GetMouseButton(0) && Vertical == false)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                    transform.eulerAngles.y - Input.GetAxis("Mouse X") * 5,
                    transform.eulerAngles.z);
            }

            if (Input.GetMouseButton(0) && Vertical == true)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                    transform.eulerAngles.y - Input.GetAxis("Mouse X") * 5,
                    transform.eulerAngles.z + Input.GetAxis("Mouse Y") * 5);
            }

        }
        else if (flag == false)
        {
            CloseLevelfunk();
        }
    }

    //void EndRotate()
    // void{
    //     float angleRight = Quaternion.Angle(transform.rotation, targetRigth.rotation);
    //     if (angleRight < tolerance)
    //     {
    //         while()
    //     }
    // }
    void CloseLevelfunk()
    {
        int i;
        int test;
        test = PlayerPrefs.GetInt("test");
        i = PlayerPrefs.GetInt("levelcomplite");
        if (i < levl && test == 0)
            PlayerPrefs.SetInt("levelcomplite", levl);
        PlayerPrefs.SetInt("firstload", 0);
        BackCloseLevel.SetActive(true);
        Retry.SetActive(true);
        Text.SetActive(true);
        Back.SetActive(false);
        Cursor.visible = true;
    }

    void Pause()
    {
        if (!BackCloseLevel.activeSelf)
        {
            if (flag == false)
                flag = true;
            else
                flag = false;
            Cursor.visible = flag;
            Retry.SetActive(flag);
            Back.SetActive(flag);
        }
    }
}