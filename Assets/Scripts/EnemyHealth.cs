using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]private int health = 100;
    [SerializeField]private int damage = 50;
    GameObject scoreboard;

    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        scoreboard = GameObject.Find("/Canvas/score");
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("bullet"))
        {
            health -= damage;
        }
        
        if (health <= 0)
        {
            
            anim.SetBool("Dead", true);
            gameObject.GetComponent<EnemyController>().enabled = false;
            StartCoroutine(destroy());
        }
    }
        
        IEnumerator destroy(){
            //play your sound
            yield return new WaitForSeconds(2); 
            scoreboard.GetComponent<Score>().addScore(1);
            Destroy(gameObject);
        }
}

