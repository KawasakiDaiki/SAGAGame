using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResuleText : MonoBehaviour {
    public Text[] text;
    // Use this for initialization
    void Start () {
        int onetap = 1000000 / (GaneCom.p + GaneCom.g + GaneCom.m);
        int score = (onetap* GaneCom.p)+(onetap/2 * GaneCom.g);
        text[0].text = score.ToString("D7");
        text[1].text = GaneCom.p.ToString();
        text[2].text = GaneCom.g.ToString();
        text[3].text = GaneCom.m.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
