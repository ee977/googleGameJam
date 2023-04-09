using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;

    private Transform player;
    private Vector2 target;
    private Rigidbody2D rb;

    [SerializeField]
    private float dmg = 10;

    [SerializeField]public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb= GetComponent<Rigidbody2D>();

        Vector3 direction = player.transform.position - transform.position;



        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rot + 180);


        //transform.Rotate(0, 0, Mathf.Tan((transform.position.x-target.x)/(transform.position.y-target.y)));
        //transform.Rotate(0,0,Mathf.Tan(Mathf.Abs (player.position.y - transform.position.y)/Mathf.Abs( player.position.x - transform.position.x)));
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the enemy collides with the player, apply damage
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().Damage(dmg);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "eye")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);
        }else if (collision.gameObject.tag == "Player"){
            
            player.GetComponent<PlayerHealth>().Damage(dmg);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);

        }else if (collision.gameObject.tag == "stage"){
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);
        }
        
    }
    
}