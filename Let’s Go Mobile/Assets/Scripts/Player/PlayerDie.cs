using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public ParticleSystem Explosion;
    public GameObject PlayerModel;
    public static bool IsAlive = true;

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Die();
        }
    }
    
    void Die()
    {
        //Explosion.Play();
        Debug.Log("Hit!");
        //PlayerMovement.speed = 0.0f;
        Destroy(PlayerModel);
        IsAlive = false;
        Application.LoadLevel(0);
    }
}