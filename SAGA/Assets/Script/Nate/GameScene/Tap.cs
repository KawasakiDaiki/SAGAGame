using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tap : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start () {
        if (OntouchDown())
        {
            text.text = "1";
        }
        else
        {
            text.text = "0";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    bool OntouchDown()
    {
        if (0 < Input.touchCount)
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                if (t.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(t.position);
                    RaycastHit hit = new RaycastHit();
                    if(Physics.Raycast(ray,out hit))
                    {
                        if (hit.collider.gameObject == this.gameObject)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}
