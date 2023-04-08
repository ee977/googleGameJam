using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ClearSky;
using TMPro;




    public class PlayerHealth : MonoBehaviour
        {
            [SerializeField] private float health = 100;
            private Animator anim;
            [SerializeField]private TMP_Text text;
    
            private int MAX_HEALTH = 100;
            
            void Awake()
            {
                anim = GetComponent<Animator>();
                text.text = "" + health;
            }
       
            void Update(){
                if (Input.GetKeyDown(KeyCode.Mouse0)){
                    Damage(10);
                }
                if (Input.GetKeyDown(KeyCode.H)){
                    Heal(10);
                }
                
            }
    
            public void Damage(float amount){
                if(amount < 0){
                    throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
                }
    
                this.health -= amount;
                text.text = "" + health;
    
                if(health <= 0){
                    Die();
                    text.text = "0";
                }
            }
    
            public void Heal(int amount){
                if (amount < 0){
                    throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
                }
    
                bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;
    
                if (wouldBeOverMaxHealth){
                    this.health = MAX_HEALTH;
                }else{
                    this.health += amount;
                }
            }
    
            private void Die()
            {
                Debug.Log("I am Dead!");
                anim.SetTrigger("die");
            }
        }
