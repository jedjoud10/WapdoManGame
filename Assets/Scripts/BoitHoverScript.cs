using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoitHoverScript : MonoBehaviour
{
    private Rigidbody rb;
    public float mindistance;
    public float force;
    private RaycastHit hit;
    public float lerpupvector;
    public ParticleSystem particles;
    private ParticleSystem.EmissionModule em;
    public GameObject player;
    public float speed;
    public float speedrotation;
    public float speedup;
    public float thresholdrot;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(rb.position, -rb.transform.up * 9999, out hit))
        {
            if (hit.distance < mindistance)
            {
                rb.AddForce(Vector3.Lerp(rb.transform.up, Vector3.up, lerpupvector) * force * Time.deltaTime);
                em = particles.emission;
                em.enabled = true;
            }
            else
            {
                em = particles.emission;
                em.enabled = false;
            }
        }
        if (player != null)
        {
            Vector3 targetDelta = player.transform.position - transform.position;
            float angleDiff = Vector3.Angle(transform.forward, targetDelta);
            Vector3 cross = Vector3.Cross(transform.forward, targetDelta);
            rb.AddTorque(cross * angleDiff * speedrotation * Time.deltaTime);
        }
        if (Vector3.Dot(rb.transform.up, Vector3.down) > thresholdrot)
        {
            var rot = Quaternion.FromToRotation(rb.transform.up, Vector3.up);
            rb.AddTorque(new Vector3(rot.x, rot.y, rot.z) * speedup * Time.deltaTime);
        }
        rb.AddForce((rb.position - player.transform.position).normalized * speed * Time.deltaTime);
    }
}
