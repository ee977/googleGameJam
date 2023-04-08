using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ClearSky;



    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private float health = 100;
        private Animator anim;

        private int MAX_HEALTH = 100;
        
        void Awake()
        {
            anim = GetComponent<Animator>();
        }
   
        void Update(){
            if (Input.GetKeyDown(KeyCode.H)){
                Heal(10);
            }
        }

        public void Damage(float amount){
            if(amount < 0){
                throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
            }

            this.health -= amount;

            if(health <= 0){
                Die();
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

