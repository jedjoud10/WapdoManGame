using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGun : MonoBehaviour
{
    public Rigidbody pistolup;
    public GameObject anchor;
    private Vector3 pos;
    public float length;
    public float force;
    public float smooth;
    private Vector3 vel;
    public float XSpeed;
    public Vector3 offset;
    public Vector3 baseoffset;
    public float clamp;

    // Update is called once per frame
    void Update()
    {
        anchor.transform.position = Vector3.SmoothDamp(anchor.transform.position, transform.forward * length + transform.position + anchor.transform.TransformPoint(offset + baseoffset) - anchor.transform.position, ref vel, smooth);
        pos = anchor.transform.position;
        pistolup.AddForce((pos - pistolup.position) * force);
        Debug.DrawRay(pistolup.position, (pos - pistolup.position), Color.black);
        offset += new Vector3(Input.mouseScrollDelta.y * XSpeed, 0, 0);
        offset.x = Mathf.Clamp(offset.x, -clamp, clamp);
    }
}
