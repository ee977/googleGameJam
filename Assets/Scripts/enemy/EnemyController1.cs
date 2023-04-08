using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnemyController1 : MonoBehaviour
{
    // Set up variables for enemy movement and behavior
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float damage = 20.0f;
    [SerializeField]
    private float thrust = 10f;
    
    Rigidbody2D rb2D;
    Collider2D c2d;
    private Animator anim;
    private SpriteRenderer _spriteRenderer;

    void Start(){

        // Set up the player transform reference
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2D = GetComponent<Rigidbody2D>();        
        c2d = GetComponent<Collider2D>();
    }

    void FixedUpdate(){
        // Move the enemy towards the player
        transform.position = Vector2.MoveTowards(transform.position , player.position, speed * Time.deltaTime);
        //rb2D.AddForce(player.position * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other){

        print("hit");
        // If the enemy collides with the player, apply damage
        if (other.tag == "Player")
        {   
            print("hit");
            other.GetComponent<PlayerHealth>().Damage(damage);
            Vector2 direction = (other.transform.position - transform.position).normalized;


           rb2D.AddForce(-direction * thrust, ForceMode2D.Impulse);
           anim.SetTrigger("attack");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("Player", false);
    }
}