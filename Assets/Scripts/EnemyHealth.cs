using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]private int health = 100;
    [SerializeField]private int damage = 50;

    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        print("hasar");
        if (other.CompareTag("bullet"))
        {
            health -= damage;
        }
        
        if (health <= 0)
        {
            anim.SetBool("Dead", true);
            StartCoroutine(destroy());
        }
    }
        
        IEnumerator destroy(){
            //play your sound
            yield return new WaitForSeconds(4); 
            Destroy(gameObject);
        }
}

