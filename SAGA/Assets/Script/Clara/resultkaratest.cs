﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class resultkaratest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void ButtonDown()
    {
        SceneManager.LoadScene("test Scene");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
