using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetAnchoring : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject anchor;
    public float Force;
    private Vector3 direction;
    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 idle;
    public bool isidle;
    public bool usewhatpos;
    public float smoothspeed;
    private Vector3 vel;
    private Animator animcontroller;
    private bool isAnimation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (GetComponent<Animator>() != null)
        {
            animcontroller = GetComponent<Animator>();
            isAnimation = false;
        }
        else
        {
            isAnimation = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        direction = anchor.transform.position - rb.position;
        if (animcontroller == null || !isAnimation)
        {
            anchor.transform.localPosition = getpos(anchor.transform.localPosition);
        }
        if (animcontroller != null)
        {
            isAnimation = animcontroller.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animcontroller.IsInTransition(0);
        }
        rb.AddForce(direction * Force);
    }
    public void ChangeLoc()
    {

        usewhatpos = !usewhatpos;
    }
    public Vector3 getpos(Vector3 oldpos)
    {
        if (isidle)
        {
            return idle;
        }
        if (usewhatpos)
        {
            return Vector3.SmoothDamp(oldpos, pos1, ref vel, smoothspeed);
        }
        else
        {
            return Vector3.SmoothDamp(oldpos, pos2, ref vel, smoothspeed);
        }
    }
}