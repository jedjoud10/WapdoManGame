using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSword : MonoBehaviour
{
    public Rigidbody swordup;
    public GameObject anchor;
    private Vector3 pos;
    public float length;
    public float force;
    public float smooth;
    private Vector3 vel;
    public float XSpeed;
    public Vector3 offset;
    public float clamp;

    // Update is called once per frame
    void Update()
    {
        anchor.transform.position = Vector3.SmoothDamp(anchor.transform.position, transform.forward * length + transform.position + anchor.transform.TransformPoint(offset) - anchor.transform.position, ref vel, smooth);
        pos = anchor.transform.position;
        swordup.AddForce((pos - swordup.position) * force);        
        Debug.DrawRay(swordup.position, (pos - swordup.position), Color.black);
        offset += new Vector3(Input.mouseScrollDelta.y * XSpeed, 0, 0);
        offset.x = Mathf.Clamp(offset.x, -clamp, clamp);
    }
}
