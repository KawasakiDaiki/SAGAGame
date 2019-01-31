using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class testkaratitle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void ButtonDown()
    {
        SceneManager.LoadScene("title Scene");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
