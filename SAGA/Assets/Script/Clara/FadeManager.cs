using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public Image FadeImage;

    public static bool isFade;
    public static bool isFadeIn;
    public static bool isFadeOut;
    public bool des;
    float alpha;

    // Use this for initialization
    void Start ()
    {
        alpha = 1.0f;
        isFade = true;
        isFadeIn = true;
        isFadeOut = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isFade)
        {
            if (isFadeIn) FadeIn();
            else if (isFadeOut) FadeOut();
        }
    }
    public void FadeIn()
    {
        alpha -= 0.05f;
        FadeImage.color = new Color(1.0f, 1.0f, 1.0f, alpha);

        // フェードイン終了条件
        if (alpha <= 0.0f)
        {
            isFadeIn = false;
            isFade = false;
            if(des)
            Destroy(FadeImage);
        }
    }
    public void FadeOut()
    {
        alpha += 0.05f;
        FadeImage.color = new Color(1.0f, 1.0f, 1.0f, alpha);

        // フェードアウト終了条件
        if (alpha >= 1.0f)
        {
            isFade = false;
            isFadeOut = false;
        }
    }
}
