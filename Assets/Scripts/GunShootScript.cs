using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootScript : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject outnozzle;
    public GameObject muzzleflash;
    public void Shoot() 
    {
        Instantiate(Bullet, outnozzle.transform.position, outnozzle.transform.rotation);
        Destroy(Instantiate(muzzleflash, outnozzle.transform.position, outnozzle.transform.rotation), 1.0f);
    }
}
