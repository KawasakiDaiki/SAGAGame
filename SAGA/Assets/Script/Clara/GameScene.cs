using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void ButtonDown()
    {
        SceneManager.LoadScene("SAGA");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
