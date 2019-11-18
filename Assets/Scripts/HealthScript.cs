using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public float MaxHealth;
    public float myHealth;
    public Slider health;

    // Start is called before the first frame update
    void Start()
    {
        myHealth = MaxHealth;
        health.maxValue = MaxHealth;
    }

    public void HitPlayer(float damage) 
    {
        myHealth -= damage;
        health.value = myHealth;
        if (myHealth < 0)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
