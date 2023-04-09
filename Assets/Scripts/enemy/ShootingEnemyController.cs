using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyController : MonoBehaviour
{
    // Set up variables for enemy movement and behavior
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private float stopDistance = 12f;
    [SerializeField]
    private float nearDistance = 5f;
    [SerializeField]
    private float shotTime = 2;
    [SerializeField]
    private float firerate = 2;
    
    [SerializeField]
    private GameObject shot;

    Transform player;
    [SerializeField]
    Transform shootingPoint;
    [SerializeField]private int health = 100;
    [SerializeField]private int damage = 50;
    GameObject scoreboard;

    private Animator anim;
    private bool ded = false;

    void Start(){

        // Set up the player transform reference
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        scoreboard = GameObject.Find("/Canvas/score");
        
    }

    void FixedUpdate(){
        if(ded == false){
            if(Vector2.Distance(transform.position, player.position) > stopDistance){
                transform.position = Vector2.MoveTowards(transform.position , player.position, speed * Time.deltaTime);
            }else if(Vector2.Distance(transform.position, player.position) < nearDistance){
                 transform.position = Vector2.MoveTowards(transform.position , player.position, -speed * Time.deltaTime);
            }else if(Vector2.Distance(transform.position, player.position) < stopDistance && Vector2.Distance(transform.position, player.position) > nearDistance){
                transform.position = this.transform.position;
            }

            if(firerate <=0  ){
                Instantiate(shot, shootingPoint.position, Quaternion.identity);
                firerate = shotTime;
            }else{
                firerate -= Time.deltaTime;
            }
        }
        
    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("bullet"))
        {
            health -= damage;
        }
        if (health <= 0 && ded == false)
        {
            print("DEDPLS");
            ded = true;
            scoreboard.GetComponent<Score>().addScore(1);
            anim.SetBool("Dead", true);
            StartCoroutine(destroy());
        }
    }
        
    IEnumerator destroy(){
            //play your sound
        yield return new WaitForSeconds(2); 
        
        print("ded");
        Destroy(gameObject);
    }
}