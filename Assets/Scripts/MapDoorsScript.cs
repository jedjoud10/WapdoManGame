using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapDoorsScript : MonoBehaviour
{
    public GameObject nosign;
    public GameObject yessign;
    private bool canfinish;
    public string nextLevelName;
    // Start is called before the first frame update
    void Start()
    {
        nosign.SetActive(true);
        yessign.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (canfinish)
            {
                SceneManager.LoadScene(nextLevelName);
            }
        }
    }
    public void UpdateNumber() 
    {
        StartCoroutine(dedectnumberlate());
    }
    IEnumerator dedectnumberlate() 
    {
        yield return new WaitForSeconds(0.5f);
        canfinish = GameObject.FindGameObjectsWithTag("Enemy").Length < 1;
        yessign.SetActive(canfinish);
        nosign.SetActive(!canfinish);
    }
}
