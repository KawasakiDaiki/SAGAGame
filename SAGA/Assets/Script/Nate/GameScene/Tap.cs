using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tap : MonoBehaviour {
    Touch touch;
    public Text text;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float a = Input.mousePosition.x;
        float b = Input.mousePosition.y;
        text.text = a.ToString()+"\n"+ b.ToString();

    }
}
