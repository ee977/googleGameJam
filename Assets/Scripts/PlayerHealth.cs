  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ClearSky;
using TMPro;
using Unity.VisualScripting;
using Input = UnityEngine.Windows.Input;


public class PlayerHealth : MonoBehaviour
        {
            [SerializeField] public float health = 100;
            private Animator anim;
            [SerializeField]private TMP_Text text;
            [SerializeField] private GameObject canvas;
            public KarakterKontrol karakterKontrol;

            private int MAX_HEALTH = 100;
            
            void Awake()
            {
                anim = GetComponent<Animator>();
                text.text = "" + health;
            }
       
            void Update()
            {
               
            }
    
            public void Damage(float amount = 5f){
                if(amount < 0){
                    throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
                }
    
                this.health -= amount;
                text.text = "" + health;
                anim.SetTrigger("hurt");
    
                if(health <= 0){
                    Die();
                    text.text = "0";
                    karakterKontrol.enabled = false;
                    gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    Invoke(nameof(stopAnim), 1.5f);

                }
            }

            void stopAnim()
            {
                anim.enabled = false;
                canvas.SetActive(true);
                Time.timeScale = 0;
            }
    
           // public void Heal(int amount){
           //     if (amount < 0){
           //         throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
           //     }
            //
           //     bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;
            //
           //     if (wouldBeOverMaxHealth){
           //         this.health = MAX_HEALTH;
           //     }else{
           //         this.health += amount;
           //     }
           // }
    
            private void Die()
            {
                Debug.Log("I am Dead!");
                anim.SetTrigger("die");
            }
        }
