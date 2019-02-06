using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour {

    public AudioClip[] audioClips;
    public  TextAsset[] texts;
    public static AudioClip audio;
    public static string text;

    int No;

    public GameObject [] music = new GameObject[3];
    


    // Use this for initialization
    void Start ()
    {
        audio = audioClips[0];
        No = -1;
    }

    // Update is called once perg frame
    void Update ()
    {
        Debug.Log(audio.name);
        Debug.Log(No);
        switch (No)
        {
            case -1:
                music[0].SetActive(true);
                music[1].SetActive(false);
                //        music[2].SetActive(false);
                audio = audioClips[0];
                text = texts[0].name;
                break;
            case 0:
                music[0].SetActive(false);
                music[1].SetActive(true);
                //    //music[2].SetActive(false);
                audio = audioClips[1];
                text = texts[1].name;
                break;
                //case 1:
                //    music[0].SetActive(false);
                //    music[1].SetActive(false);
                //    music[2].SetActive(true);
                //    audio = audioClips[2];
                //    break;
        }
    }
    public void LButton()
    {
        if (No > -1)
            No -= 1;

    }
    public void RButton()
    {
        if (No < 0)
            No += 1;

    }
}
