using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GaneCom : MonoBehaviour
{

    int num = 1, reenNum = 0, BPM = 1;
    int count_x = 0,count_y,reenCount,NoteCou;
    int tapNum;
    bool cha = false;
    static bool StartTriger=false;
    float timing,delta;
    public string FilePass;
    public GameObject note, reen;
    int[] lineNum;
    float[] X,Y,pushtiming;//レーン：列：タッチ時間
    GameObject[] notes;

    Touch touch;
    public Text text;

    // Use this for initialization
    void Start()
    {
        X = new float[1];
        Y = new float[1];
        pushtiming = new float[1];
        notes = new GameObject[1];
        num = 1;
        count_x = 0;
        LodeCSV();
        NoteCle();
        
        //Debug.Log(X[0] + "_" + Y[0]);
    }

    // Update is called once per frame
    void Update()
    {
        //start準備(ノーツの生成)
        if (cha)
        {
            //スタート
            if (StartTriger)
            {
                Debug.Log(delta);
                delta += Time.deltaTime;
                while (delta >= pushtiming[reenNum]+1 && NoteCou > 0)
                {
                    notes[reenNum].SetActive(true);
                    reenNum++;
                    NoteCou--;
                }
                if (NoteCou <= 0)
                {
                    cha = false;
                    delta = 0;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    float a = Input.mousePosition.x;
                    float b = Input.mousePosition.y;
                    text.text = a.ToString() + "\n" + b.ToString();
                    if (true)
                    {

                    }
                }
            }
        }
    }
    //読み込んだcsvの情報からノートを生成
    void NoteCle()
    {
        foreach (int i in lineNum)
        {
            float pos = reen.transform.position.x + (0.5f * count_x);
            
            if (i == 1)
            {
                Debug.Log("a");
                X[reenCount] = count_x;
                Y[reenCount] = count_y;
                pushtiming[reenCount] = count_y * 0.5f * BPM;
                notes[reenCount] = Instantiate(note, new Vector3(pos, 0, 6), Quaternion.identity);
                reenCount++;
                NoteCou++;
                Array.Resize(ref pushtiming, reenCount + 1);
                Array.Resize(ref X, reenCount + 1);
                Array.Resize(ref Y, reenCount + 1);
                Array.Resize(ref notes, reenCount + 1);
            }
            count_x++;
            if (count_x > 6)
            {
                count_x = 0;
                count_y++;
            }
        }
        cha = true;
    }
    //csv読み込み
    void LodeCSV()
    {
        lineNum = new int[num];
        //FilePassが譜面ファイル名
        TextAsset csv = Resources.Load("CSV/" + FilePass) as TextAsset;
        StringReader reader = new StringReader(csv.text);


        int i = 0;
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            int h=0;
            while (values.Length != h)
            {
                Debug.Log(values[h]);
                h++;
            }
            for (int j = 0; j < values.Length; j++, i++)
            {
                if (values[j] == "1")
                {
                    lineNum[i] = 1;
                }
                num++;
                Array.Resize(ref lineNum, num);
            }

        }
    }
    //スタートボタン、後で消す
    public void start()
    {
        StartTriger = true;
    }
}

