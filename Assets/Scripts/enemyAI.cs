using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public float moveSpeed;
    public float attackRange;
    public float attackCooldown;
    public int damage;

    private Transform target;
    private UnityEngine.AI.NavMeshAgent navAgent;
    private Animator anim;
    private bool canAttack = true;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget <= attackRange && canAttack)
            {
                StartCoroutine(AttackPlayer());
            }
            else
            {
                navAgent.SetDestination(target.position);
            }

            anim.SetFloat("Speed", navAgent.velocity.magnitude);
        }
    }

    IEnumerator AttackPlayer()
    {
        canAttack = false;
        anim.SetTrigger("Attack");

        yield return new WaitForSeconds(attackCooldown);

        if (target != null)
        {
            PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                //playerHealth.TakeDamage(damage);
            }
        }

        canAttack = true;
    }
}
