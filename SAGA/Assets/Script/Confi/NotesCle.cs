using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesCle : MonoBehaviour {
    public GameObject note;
    [SerializeField] GameObject DefReen;
    Vector3 Vec;
	// Use this for initialization
	void Start () {
        Vec = new Vector3(DefReen.transform.position.x, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(note, new Vector3(DefReen.transform.position.x + 0.5f * 0, 0, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(note, new Vector3(DefReen.transform.position.x + 0.5f * 1, 0, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(note, new Vector3(DefReen.transform.position.x + 0.5f * 2, 0, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(note, new Vector3(DefReen.transform.position.x + 0.5f * 3, 0, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(note, new Vector3(DefReen.transform.position.x + 0.5f * 4, 0, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(note, new Vector3(DefReen.transform.position.x + 0.5f * 5, 0, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Instantiate(note, new Vector3(DefReen.transform.position.x + 0.5f * 6, 0, 0), Quaternion.identity);
        }
    }
}
