using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;

    private Transform player;
    private Vector2 target;

    [SerializeField]
    private float dmg = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the enemy collides with the player, apply damage
        if (other.tag == "Player"){
            other.GetComponent<PlayerHealth>().Damage(dmg);
        }

        Destroy(gameObject);
    }
}
