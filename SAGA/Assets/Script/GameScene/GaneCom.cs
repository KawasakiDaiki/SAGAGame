using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GaneCom : MonoBehaviour
{
    int p, g, m;
    int num , BPM = 1, cou = 1;
    int a, reenNum,TapReen;
    int count_x = 0, count_y, reenCount, NoteCou;
    int tapNum;
    public int count_i;
    bool cha = false, notefalse = false;
    static bool StartTriger = false;
    float timing, delta, pushDel,ActiveTime=0.3f;
    public string FilePass;
    public GameObject note, reen, button;
    public AudioClip audio;
    AudioSource audiosourse;
    int[] lineNum, touchNum;
    float[] X, Y, pushtiming;//レーン：列：タッチ時間
    //GameObject[] notes;
    public GameObject[] reencolor;
    public Text[] text;
    KeyCode key;
    RaycastHit hit;
    Color mat;
    bool test_a=false, test_b=false;


    //ノーツが格納されている配列
    [SerializeField]S_NATE_STATUS[] NateArray;
    //判定用のリスト
    List<S_NATE_STATUS> ActiveNateList = new List<S_NATE_STATUS>();
    struct S_NATE_STATUS
    {
        public GameObject obj;
        public float time;
        public int lineNum;
    }
    

    // Use this for initialization
    void Start()
    {
        //X = new float[1];
        //Y = new float[1];
        lineNum = new int[1];
        //pushtiming = new float[1];
        //notes = new GameObject[1];
        audiosourse = GetComponent<AudioSource>();
        cou = 1;
        reenNum = 0;
        count_x = 0;
        count_i = 0;
        LodeCSV();
        NoteCle();
        mat = reen.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        //float fps = 1f / Time.deltaTime;
        //Debug.LogFormat("{0}fps", fps);
        //start準備(ノーツの生成)
        if (!cha)
        {
            delta += Time.deltaTime;
            if (delta >= 5)
            {
                SceneManager.LoadScene("result");
            }
        }
        if (cha)
        {
            //foreach(var a in NateArray)
            //{
                //Debug.Log("NateArray.Length:" + NateArray.Length);
            //}
            //StartTriger = true;
            //開始エフェクト後にスタート
            if (StartTriger)//開始エフェクト後にon
            {
                //Debug.Log("来た");
                notefalse = false;
                //Debug.Log(delta);
                delta += Time.deltaTime;
                //生成
                while (audiosourse.time >= NateArray[reenNum].time - 1.0f*2 && reenNum < NoteCou)
                {
                    //Debug.Log("reenNum:" + reenNum);
                    NateArray[reenNum].obj.SetActive(true);
                    reenNum++;
                    //NoteCou--;

                    test_a = true;
                }
                //判定許容時間内
                //Debug.Log("cou:"+cou);
                while (audiosourse.time + 0.3f >= NateArray[cou].time&& NateArray.Length-1 > cou && test_a==true)
                {
                    ActiveNateList.Add(NateArray[cou]);
                    cou++;
                    //Debug.Log("動いている？");
                    test_b = true;
                }
                //判定許容時間外
                if (test_b == true && ActiveNateList[0].time <= audiosourse.time - 0.3f)
                {
                    ActiveNateList.RemoveAt(0);
                    //Debug.Log("やっほ");
                    if(ActiveNateList.Count==0)
                    test_b = false;
                }
                
                

                GetBottenKey();

                //タッチ判定
                if (0 < Input.touchCount)
                {
                    for (int i = 0; i < Input.touchCount; i++)
                    {
                        Touch t = Input.GetTouch(i);
                        if (t.position.y <= 450)
                        {
                            if (t.phase == TouchPhase.Began)
                            {
                                Ray ray = Camera.main.ScreenPointToRay(t.position);
                                if(Physics.Raycast(ray,out hit))
                                {
                                    text[1].text = hit.collider.gameObject.name;
                                    TapReen = -48+hit.collider.gameObject.name[5];
                                    PushKey(TapReen);
                                }
                            }
                        }
                    }
                }

                //終了処理
                if (count_i >= NateArray.Length-1)
                {
                    text[0].text = "ok";
                    cha = false;
                    StartTriger = false;
                    delta = 0;
                }
            }
        }
    }
    public void Click_Collar(int ReenNum)
    {
        reencolor[ReenNum].GetComponent<Renderer>().material.color=Color.yellow;
    }
    public void NoClick_Collar(int ReenNum)
    {
        reencolor[ReenNum].GetComponent<Renderer>().material.color = mat;
    }

    void PushKey(int num)
    {
        //text[0].text = TapReen.ToString() + "_" + NateArray[count_i].lineNum;
        
        foreach(var a in ActiveNateList)
        {
            if (a.lineNum == num)
            {
                float deltaTime = audiosourse.time - a.time;
                if (deltaTime >= -0.02f && deltaTime <= 0.02f)
                {
                    notefalse = true;
                }
                else if (deltaTime >= -0.04f && deltaTime <= 0.04f)
                {
                    notefalse = true;
                }
                else if (deltaTime >= -0.07f && deltaTime <= 0.07f)
                {
                    notefalse = true;
                }
                if (notefalse)
                {
                    //Debug.Log("ok");
                    a.obj.SetActive(false);
                    notefalse = false;
                    count_i++;
                }
                break;
            }
        }
    }

            



    //読み込んだcsvの情報からノートを生成
    void NoteCle()
    {
        List<S_NATE_STATUS> list = new List<S_NATE_STATUS>();

        foreach (int i in lineNum)
        {
            float pos = reen.transform.position.x + (0.5f * count_x);
            S_NATE_STATUS status = new S_NATE_STATUS();

            if (i == 1)
            {
                //Debug.Log("a");
                //pushtiming[reenCount] = count_y * 0.0625f * BPM;

                //
                status.obj = Instantiate(note, new Vector3(pos, 0, 6), Quaternion.identity);
                status.obj.name = "NOTE's" + reenCount;
                status.time = count_y * 0.0625f * BPM;
                status.lineNum = count_x;
                list.Add(status);
                //

                //notes[reenCount] = Instantiate(note, new Vector3(pos, 0, 6), Quaternion.identity);
                //notes[reenCount].name = "NOTE's" + reenCount;
                reenCount++;
                NoteCou++;
                //Array.Resize(ref pushtiming, reenCount + 1);
                //Array.Resize(ref notes, reenCount + 1);
            }
            //lineNum[cou] = count_x;
            count_x++;
            if (count_x > 6)
            {
                count_x = 0;
                count_y++;
            }
        }
        cha = true;
        NateArray = new S_NATE_STATUS[list.Count+1];
        for(int i=0;i<NateArray.Length-1;i++)
        {
            NateArray[i] = list[i];
        }
    }
    //csv読み込み
    void LodeCSV()
    {
        
        //FilePassが譜面ファイル名
        TextAsset csv = Resources.Load("CSV/" + FilePass) as TextAsset;
        StringReader reader = new StringReader(csv.text);

        //Debug.Log("csv:"+csv);

        int i = 0;
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            int h=0;
            while (values.Length != h)
            {
                //Debug.Log("values[h]"+values[h]);
                h++;
            }
            for (int j = 0; j < values.Length; j++, i++)
            {
                num++;
                Array.Resize(ref lineNum, num);
                if (values[j] == "1")
                {
                    lineNum[i] = 1;
                }
            }
        }
    }

    //エディタでの入力
    void GetBottenKey()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PushKey(0);
            Click_Collar(0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            NoClick_Collar(0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            PushKey(1);
            Click_Collar(1);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            NoClick_Collar(1);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            PushKey(2);
            Click_Collar(2);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            NoClick_Collar(2);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            PushKey(3);
            Click_Collar(3);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            NoClick_Collar(3);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            PushKey(4);
            Click_Collar(4);
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            NoClick_Collar(4);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            PushKey(5);
            Click_Collar(5);
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            NoClick_Collar(5);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            PushKey(6);
            Click_Collar(6);
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            NoClick_Collar(6);
        }
    }

        //スタートボタン、後で消す
        public void start()
    {
        text[0].text = "STRAT";
        StartTriger = true;
        audiosourse.clip = audio;
        audiosourse.Play();
        button.SetActive(false);
    }
}

