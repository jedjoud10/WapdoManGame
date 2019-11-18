using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera playercam;
    public Camera guncam;
    public float animtimespeed;
    public float movingthreshold;
    public GameObject cameraVar;
    public bool canMove;
    public float sensivityCamera;
    private float XAxis;
    private Vector3 rot;
    private CharacterController cr;
    public float Speed;
    public float Gravity;
    public float JumpForce;
    private Vector3 mov;
    public float effort;
    public bool ismoving;
    private bool wasidle;
    public float clamp;
    public Animation sword;
    public Animation swordanchor;
    private float SelectGunSword;
    public CameraSword cs;
    public GunShootScript gun;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        cr = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        InvokeRepeating("MoveAnimVoid", 0, animtimespeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectGunSword < 0.0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                AttackSword1();
            }
            if (Input.GetMouseButtonDown(1))
            {
                AttackSword2();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                gun.Shoot();
            }
            if (Input.GetMouseButton(1))
            {
                playercam.gameObject.SetActive(false);
                guncam.gameObject.SetActive(true);
            }
            else
            {
                playercam.gameObject.SetActive(true);
                guncam.gameObject.SetActive(false);
            }
        }
        SelectGunSword = cs.offset.x;
        XAxis += Input.GetAxis("Mouse Y") * sensivityCamera;
        XAxis = Mathf.Clamp(XAxis, -clamp, clamp);
        rot = cameraVar.transform.eulerAngles;
        rot.x = -XAxis;
        if (canMove)
        {
            cameraVar.transform.eulerAngles = rot;
            gameObject.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * sensivityCamera, 0));
        }
        if (cr.isGrounded)
        {
            if (canMove)
            {
                mov = gameObject.transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * Speed * Time.deltaTime));
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    mov.y = JumpForce;
                }
                effort = mov.magnitude;
                ismoving = effort > movingthreshold;
            }
            else
            {
                mov = Vector3.zero;
            }
        }
        mov.y -= Gravity * Time.deltaTime;
        cr.Move(mov);
    }
    public void MoveAnimVoid()
    {
        if (ismoving)
        {
            GetComponent<CharachterPhysics>().Move();
            wasidle = false;
        }
        if(!ismoving && !wasidle)
        {
            GetComponent<CharachterPhysics>().idle();
            wasidle = true;
        }
    }
    public void AttackSword1()
    {
        sword.Play("AttackSword");
        swordanchor.Play("AttackSwordAnchor");
    }
    public void AttackSword2()
    {
        sword.Play("AttackSword2");
        swordanchor.Play("AttackSwordAnchor2");
    }
}