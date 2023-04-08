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

    void Start(){

        // Set up the player transform reference
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    void FixedUpdate(){
        
        if(Vector2.Distance(transform.position, player.position) > stopDistance){
            transform.position = Vector2.MoveTowards(transform.position , player.position, speed * Time.deltaTime);
        }else if(Vector2.Distance(transform.position, player.position) < nearDistance){
            transform.position = Vector2.MoveTowards(transform.position , player.position, -speed * Time.deltaTime);
        }else if(Vector2.Distance(transform.position, player.position) < stopDistance && Vector2.Distance(transform.position, player.position) > nearDistance){
            transform.position = this.transform.position;
        }

        if(firerate <=0){
            Instantiate(shot, shootingPoint.position, shootingPoint.rotation);
            firerate = shotTime;
        }else{
            firerate -= Time.deltaTime;
        }
    
    }
}