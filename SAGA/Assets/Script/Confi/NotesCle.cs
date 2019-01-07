using UnityEngine;
using System.Collections;
using System;

public class NotesCle : MonoBehaviour {
    public GameObject note;
    CSVWrite CSVW;
    [SerializeField] GameObject DefReen;
    Vector3 Vec;
    float delta, _startTime;
    float[] time=new float[1];
    int[] reenNum=new int[1];
    int count, WriteCount, timeNum;
    char[] WriteReen=new char[7];
    bool WriteTrigger = false;
    // Use this for initialization
    void Start() {
        count = 0;
        WriteCount = 1;
        Vec = new Vector3(DefReen.transform.position.x, 0, 0);
        CSVW = GetComponent<CSVWrite>();
        _startTime = Time.time;
    }

    // Update is called once per frame
    void Update() {
        BGet();
    }
    void BGet()
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
        }
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
        for(int t=0;t<time.Length;t++,timeNum++)
        {
            if (0.5f * WriteCount >= time[t] && 0.5f*WriteCount-1<time[t])
            {
                WriteReen[reenNum[t]] = '1';
            }
            if (0.5f * WriteCount < t)
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
    }
}
