using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
 public GameObject target;
 public powerup_effect powerupEffect;



 private void OnTriggerEnter2D(Collider2D collision)
 {
  if (target.GetComponent<PlayerHealth>().health < 100)
  {
   Destroy(gameObject);
   powerupEffect.Apply(collision.gameObject);
  }
  
 }
}