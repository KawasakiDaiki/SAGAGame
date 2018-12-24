using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NateCon : MonoBehaviour {
    public Vector3 startPos = new Vector3 (0.0f, 0.0f, 6.0f);
    public Vector3 linePos = new Vector3 (0.0f, 0.0f, -4.0f);

    // Update is called once per frame
    void Update()
    {
        float len = Vector3.Distance(startPos, linePos);
        transform.position += new Vector3(0, 0, -len * Time.deltaTime);
        if (transform.position.z < -5)
        {
            gameObject.SetActive(false);
        }
    }
}
