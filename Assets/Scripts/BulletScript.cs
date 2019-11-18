using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float damage;
    private Rigidbody rb;
    public float speed;
    public float mult1;
    public float mult2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(rb.transform.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDelta = rb.velocity * mult1;
        float angleDiff = Vector3.Angle(transform.forward, targetDelta);
        Vector3 cross = Vector3.Cross(transform.forward, targetDelta);
        rb.AddTorque(cross * angleDiff * mult2);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyClass>() != null)
        {
            collision.gameObject.GetComponent<EnemyClass>().HitEnemy(damage);
        }
        Destroy(gameObject);
    }
}
