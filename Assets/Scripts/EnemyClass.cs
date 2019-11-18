using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    public float damage;
    public float Health;
    public float Protection;
    public float replaydelay;
    public Vector2Int randomidlerange;
    public AudioClip[] idlesounds;
    public AudioClip[] attackedsounds;
    private AudioSource ausd;
    private GameObject player;
    public GameObject missileprefab;
    public float missilespawntime;
    public Vector3 offsetspawn;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ausd = GetComponent<AudioSource>();
        InvokeRepeating("PlayIdleSound", 0.0f, replaydelay);
        if (missilespawntime != 0)
        {
            InvokeRepeating("SpawnMissiles", 0.0f, missilespawntime);
        }        
    }
    public void HitEnemy(float damage)
    {
        if (Health > 0)
        {
            Health -= damage / Protection;
            ausd.PlayOneShot(attackedsounds[Random.Range(0, attackedsounds.Length)]);
        }
        //Debug.Log(Health);
        if (Health <= 0)
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("DoorsEnd").GetComponent<MapDoorsScript>().UpdateNumber();
        }
    }
    public void PlayIdleSound()
    {
        if (Random.Range(randomidlerange.x, randomidlerange.y) == 0)
        {
            ausd.PlayOneShot(idlesounds[Random.Range(0, idlesounds.Length)]);
        }        
    }
    public void SpawnMissiles() 
    {
        Instantiate(missileprefab, transform.position + offsetspawn, transform.rotation);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<HealthScript>() != null)
        {
            collision.gameObject.GetComponent<HealthScript>().HitPlayer(damage);
        }
    }
}
