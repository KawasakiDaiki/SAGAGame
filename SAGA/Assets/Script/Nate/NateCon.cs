using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NateCon : MonoBehaviour {
    public Vector3 startPos = new Vector3 (0.0f, 0.0f, 6.0f);
    public Vector3 linePos = new Vector3 (0.0f, 0.0f, -4.0f);
    Vector3 notePos;
    float len,delta;
    void Start()
    {
        notePos = transform.position;
       len= Vector3.Distance(startPos, linePos);
    }
    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        transform.localPosition =new Vector3(notePos.x,notePos.y,notePos.z-len * delta);
        if (transform.position.z < -5)
        {
            gameObject.SetActive(false);
        }
    }
}
