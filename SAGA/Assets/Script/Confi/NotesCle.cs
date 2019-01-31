using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class NotesCle : MonoBehaviour {
    public GameObject note;
    public AudioClip audio;
    AudioSource audiosourse;
    CSVWrite CSVW;
    [SerializeField] GameObject DefReen;
    float delta, _startTime;
    float[] time=new float[1];
    int[] reenNum=new int[1];
    int count, WriteCount, timeNum;
    char[] WriteReen=new char[7];
    bool WriteTrigger = false;
    bool StartRead=false;
    public Button But;
    [SerializeField]Text text;
    // Use this for initialization
    void Start() {
        count = 0;
        WriteCount = 1;
        CSVW = GetComponent<CSVWrite>();
        _startTime = Time.time;
        audiosourse = gameObject.GetComponent<AudioSource>();
        for (int i = 0; i < 7; i++)
        {
            WriteReen[i] = ' ';
        }
    }

    // Update is called once per frame
    void Update() {
        BGet();
    }
    void BGet()
    {
        if(StartRead)
        GetBottenKey();

        if (WriteTrigger)
        {
            WriteCSV();
        }
    }
    public void WriteC(int num)
    {
        Array.Resize(ref time, count + 1);
        Array.Resize(ref reenNum, count + 1);
        time[count] = GetTiming();
        reenNum[count] = num;
        //CSVW.WriteCSV(GetTiming().ToString() + "," + num.ToString());
        Instantiate(note, new Vector3(DefReen.transform.position.x + 0.5f * num, 0, 0), Quaternion.identity);
        count++;
    }
    public float GetTiming()
    {
        return Time.time - _startTime;
    }
    void WriteCSV()
    {
        text.text = "書き出し中...";
        for(int t=timeNum;t<time.Length;t++,timeNum++)
        {

            if (0.0625f * WriteCount >= time[t] && 0.0625f*WriteCount-1<time[t])

            if (0.0625 * WriteCount >= time[t] && 0.0625f*WriteCount-1<time[t])
>>>>>>> dc68587b32e2e6acd38bd792188c62073dbd024b
            {
                WriteReen[reenNum[t]] = '1';
            }
            if (0.0625f * WriteCount < time[t])
            {
                break;
            }   
        }
        WriteCount++;
        CSVW.WriteCSV(WriteReen[0]+","+WriteReen[1]+"," + WriteReen[2] + "," + WriteReen[3] + "," + WriteReen[4] + "," + WriteReen[5] + "," + WriteReen[6]);
        for (int i = 0; i < 7; i++)
        {
            WriteReen[i] = ' ';
        }
        if (timeNum >= count)
        {
            text.text = "書き出し完了";
            WriteTrigger = false;
            But.interactable = true;
        }
    }
    public void start()
    {
        StartRead = true;
        audiosourse.PlayOneShot(audio);
        But.interactable = false;
    }
    void GetBottenKey()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            WriteC(0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            WriteC(1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            WriteC(2);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            WriteC(3);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            WriteC(4);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            WriteC(5);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            WriteC(6);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            WriteTrigger = true;
            StartRead = false;
        }
    }
}
