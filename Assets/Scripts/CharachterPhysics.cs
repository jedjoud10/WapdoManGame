using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharachterPhysics : MonoBehaviour
{
    
    public GameObject[] Rigidbodies;
    public GameObject[] AnchoredParts;
    // Start is called before the first frame update
    [ContextMenu("Move")]
    public void Move()
    {
        foreach (GameObject item in AnchoredParts)
        {
            item.GetComponent<FeetAnchoring>().isidle = false;
            item.GetComponent<FeetAnchoring>().ChangeLoc();            
        }
    }
    [ContextMenu("idle")]
    public void idle()
    {
        foreach (GameObject item in AnchoredParts)
        {
            item.GetComponent<FeetAnchoring>().isidle = true;
        }
    }
    [ContextMenu("Pause")]
    public void Pause()
    {
        foreach (GameObject item in Rigidbodies)
        {
            item.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    [ContextMenu("Unpause")]
    public void Unpause()
    {
        foreach (GameObject item in Rigidbodies)
        {
            item.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

}
