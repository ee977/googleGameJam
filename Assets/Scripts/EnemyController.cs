using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    // Set up variables for enemy movement and behavior
    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float damage = 5.0f;

    private Animator anim;

    void Start()
    {
        // Set up the player transform reference
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        // Move the enemy towards the player
        transform.position = Vector2.MoveTowards(transform.position , player.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the enemy collides with the player, apply damage
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().Damage(damage);
            anim.SetTrigger("attack");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("Player", false);
    }
}