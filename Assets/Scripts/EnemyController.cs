using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Set up variables for enemy movement and behavior
    public float speed = 3.0f;
    public Transform player;

    void Start()
    {
        // Set up the player transform reference
        if(GameObject.FindGameObjectWithTag("Player").transform != null){
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
    }

    void Update()
    {
        // Move the enemy towards the player
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the enemy collides with the player, apply damage
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage();
        }
    }
}