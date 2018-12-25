using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVWrite : MonoBehaviour {
    public string filename;
    // Use this for initialization
    //void Start()
    //{
    //    WriteCSV("Hello,World");
    //}
    public void WriteCSV(string txt)
    {
        StreamWriter streamWriter;
        FileInfo fileInfo;
        fileInfo= new FileInfo(Application.dataPath + "/" + filename + ".csv");
        streamWriter = fileInfo.AppendText();
        streamWriter.WriteLine(txt);
        streamWriter.Flush();
        streamWriter.Close();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
