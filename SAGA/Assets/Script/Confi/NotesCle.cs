using UnityEngine;

public class NotesCle : MonoBehaviour {
    public GameObject note;
    CSVWrite CSVW;
    [SerializeField] GameObject DefReen;
    Vector3 Vec;
    float delta, _startTime;
    // Use this for initialization
    void Start () {
        Vec = new Vector3(DefReen.transform.position.x, 0, 0);
        CSVW = GetComponent<CSVWrite>();
        _startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
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
    }
    void WriteC(float num)
    {
        CSVW.WriteCSV(GetTiming().ToString() + "," + num.ToString());
        Instantiate(note, new Vector3(DefReen.transform.position.x + 0.5f * num, 0, 0), Quaternion.identity);
    }
    float GetTiming()
    {
        return Time.time - _startTime;
    }
}
