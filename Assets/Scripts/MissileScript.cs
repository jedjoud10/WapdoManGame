using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public float Damage;
    public GameObject player;
    public GameObject particles;
    public float rotspeed;
    public AudioClip explosionsound;
    public Vector3 playeroffset;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(rb.transform.forward * speed);
        Vector3 targetDelta = player.transform.position - transform.position + playeroffset;
        float angleDiff = Vector3.Angle(transform.forward, targetDelta);
        Vector3 cross = Vector3.Cross(transform.forward, targetDelta);
        rb.AddTorque(cross * angleDiff * rotspeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<HealthScript>() != null)
        {
            collision.gameObject.GetComponent<HealthScript>().HitPlayer(Damage);
        }
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        GetComponent<CapsuleCollider>().enabled = false;
        Destroy(gameObject, 1.0f);
        Instantiate(particles, transform.position, transform.rotation).transform.parent = gameObject.transform;
        GetComponent<AudioSource>().PlayOneShot(explosionsound);
    }
}
