using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour {

    int No;

    public GameObject [] music = new GameObject[3];
    


    // Use this for initialization
    void Start ()
    {
        No = 1;
    }

    // Update is called once perg frame
    void Update ()
    {
        Debug.Log(No);
        switch (No)
        {
            case -1:
                music[0].SetActive(true);
                music[1].SetActive(false);
                music[2].SetActive(false);
                break;
            case 0:
                music[0].SetActive(false);
                music[1].SetActive(true);
                music[2].SetActive(false);
                break;
            case 1:
                music[0].SetActive(false);
                music[1].SetActive(false);
                music[2].SetActive(true);
                break;
        }
    }
    public void LButton()
    {
        if(No>-1)
        No -= 1;
        
    }
    public void RButton()
    {
        if(No<1)
        No += 1;
       
    }
}
