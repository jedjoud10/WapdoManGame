using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float DamageMaster;
    public float SpeedDamage;
    public float BaseDamage;
    public float rigidbodyforce;
    private Rigidbody sword;
    public GameObject particles;
    public float time;
    public GameObject tipofsword;
    private GameObject mypart;
    public AudioClip hitclip;
    private AudioSource audiosource;
    private void Start()
    {
        sword = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyClass>() != null)
        {
            audiosource.PlayOneShot(hitclip);
            other.GetComponent<EnemyClass>().HitEnemy(((sword.velocity.magnitude * SpeedDamage) + BaseDamage) * DamageMaster);
            other.GetComponent<Rigidbody>().AddForceAtPosition(sword.velocity * rigidbodyforce, sword.position);
            mypart = Instantiate(particles, tipofsword.transform.position, Quaternion.identity);
            Destroy(mypart, time);
        }

    }
}
