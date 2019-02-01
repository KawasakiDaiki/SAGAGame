using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void ButtonDown()
    {
        SceneManager.LoadScene("test Scene");
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    SceneManager.LoadScene("test Scene");
        //}
	}
}
