using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class title : MonoBehaviour
{
    public Image Buttonimage;

    float alpha;

    // Use this for initialization
    void Start ()
    {
        alpha = 1.0f;
	}

    public void ButtonDown()
    {
        alpha = 0.0f;
        Buttonimage.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        FadeManager.isFade = true;
        FadeManager.isFadeOut = true;
        Invoke("Scene", 1.5f);
    }
    void Scene()
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
