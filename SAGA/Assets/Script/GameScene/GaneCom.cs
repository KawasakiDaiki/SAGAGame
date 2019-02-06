using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GaneCom : MonoBehaviour
{
    public static int p, g, m;
    int num, BPM = 1, cou = 1;
    int reenNum, TapReen;
    public int conbo;
    int count_x = 0, count_y, reenCount, NoteCou;
    int tapNum;
    public int count_i;
    bool cha = false, notefalse = false;
    static bool StartTriger = false;
    float delta , ActiveTime = 0.3f;
    string FilePass;
    public GameObject note, reen, button;
    AudioClip audio;
    AudioSource audiosourse;
    int[] lineNum, touchNum;
    float[] X, Y, pushtiming;//レーン：列：タッチ時間
    //GameObject[] notes;
    public GameObject[] reencolor;
    public Text[] text;
    KeyCode key;
    RaycastHit hit;
    Color mat;
    bool test_a = false, test_b = false,startGame=false;
    Animator animator;

    //ノーツが格納されている配列
    [SerializeField] S_NATE_STATUS[] NateArray;
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
        p = 0;
        g = 0;
        m = 0;
        this.audio = test.audio;
        FilePass = test.text;
        Debug.Log(FilePass);
        lineNum = new int[1];
        audiosourse = GetComponent<AudioSource>();
        cou = 0;
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
        delta += Time.deltaTime;
        //プレイ終了
        if (!cha)
        {
            if (startGame==true && delta >= 5)
            {
                Debug.Log("bbbb");
                SceneManager.LoadScene("result");
            }
        }
        //start準備(ノーツの生成)終了でtrue
        if (cha)
        {
            if (startGame== false && delta >= 1.5f)
            {
                Debug.Log("aaaa");
                text[0].text = "STRAT";
                StartTriger = true;
                audiosourse.clip = audio;
                audiosourse.Play();
                startGame = true;
            }
            //開始エフェクト後にスタート
            if (StartTriger)//開始エフェクト後にon
            {
                text[0].text = conbo.ToString();
                notefalse = false;
                delta += Time.deltaTime;

                //生成
                while (audiosourse.time >= NateArray[reenNum].time - 1.0f && reenNum < NoteCou)
                {
                    NateArray[reenNum].obj.SetActive(true);
                    reenNum++;
                    test_a = true;
                }

                //判定許容時間内
                while (audiosourse.time + 0.5f >= NateArray[cou].time && NateArray.Length - 1 > cou && test_a == true)
                {
                    ActiveNateList.Add(NateArray[cou]);
                    cou++;
                    test_b = true;
                }
                GetBottenKey();

                //判定許容時間外
                if (test_b == true && ActiveNateList.Count > 0 && ActiveNateList[0].time <= audiosourse.time - 0.5f)
                {
                    ActiveNateList.RemoveAt(0);
                    
                }
                

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
                                //タップ音再生
                                Ray ray = Camera.main.ScreenPointToRay(t.position);
                                if (Physics.Raycast(ray, out hit))
                                {
                                    TapReen = -48 + hit.collider.gameObject.name[5];
                                    PushKey(TapReen);
                                }
                            }
                            if(t.phase == TouchPhase.Ended)
                            {
                                Ray ray = Camera.main.ScreenPointToRay(t.position);
                                if (Physics.Raycast(ray, out hit))
                                {
                                    TapReen = -48 + hit.collider.gameObject.name[5];
                                    NoClick_Collar(TapReen);
                                }
                                
                            }
                        }
                    }
                }
                Debug.Log(m);
                //終了処理
                if (audiosourse.time>=audiosourse.clip.length)
                {
                    text[0].text = "ok";
                    cha = false;
                    StartTriger = false;
                    delta = 0;
                }
            }
        }
    }
    //タップのレーンの色
    public void Click_Collar(int ReenNum)
    {
        //reencolor[ReenNum].GetComponent<Animator>().SetBool("tap", true);
        reencolor[ReenNum].GetComponent<Renderer>().material.color = Color.yellow;
    }
    public void NoClick_Collar(int ReenNum)
    {
        reencolor[ReenNum].GetComponent<Renderer>().material.color = mat;
    }
  
    //タップ判定
    void PushKey(int num)
    {
        //text[0].text = TapReen.ToString() + "_" + NateArray[count_i].lineNum;
        Click_Collar(num);
        int a_cou = 0;
        foreach (var a in ActiveNateList)
        {
            if (a.lineNum == num)
            {
                float deltaTime = audiosourse.time - a.time;
                if (deltaTime >= -0.03f && deltaTime <= 0.07f)
                {
                    p++;
                    conbo++;
                    notefalse = true;
                    text[1].text = "Perfect";
                }
                else if (deltaTime >= -0.1f && deltaTime < 0.2f)
                {
                    g++;
                    conbo++;
                    notefalse = true;
                    text[1].text = "Great";
                }
                else if (deltaTime >= -0.5f && deltaTime <= 0.5f)
                {
                    m++;
                    conbo = 0;
                    notefalse = true;
                    text[1].text = "Miss";
                }
                if (notefalse)
                {
                    //Debug.Log("ok");
                    a.obj.SetActive(false);
                    notefalse = false;
                    ActiveNateList.RemoveAt(a_cou);
                    count_i++;
                }
                break;
            }
            a_cou++;
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
        NateArray = new S_NATE_STATUS[list.Count + 1];
        for (int i = 0; i < NateArray.Length - 1; i++)
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

        int i = 0;
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            int h = 0;
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
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            NoClick_Collar(0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            PushKey(1);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            NoClick_Collar(1);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            PushKey(2);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            NoClick_Collar(2);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            PushKey(3);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            NoClick_Collar(3);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            PushKey(4);
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            NoClick_Collar(4);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            PushKey(5);
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            NoClick_Collar(5);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            PushKey(6);
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            NoClick_Collar(6);
        }
    }
}

