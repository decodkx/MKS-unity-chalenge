using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Shooter enemyShooter;
    public Transform player;
    private Rigidbody2D _rigidbody;
    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        if(this.gameObject.name == "Enemy (shooter)") enemyShooter = gameObject.GetComponent<Shooter>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics2D.OverlapCircle(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics2D.OverlapCircle(transform.position, attackRange, whatIsPlayer);

        //if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) ShootPlayer();
        
    }
    private void ChasePlayer()
    {
        transform.up = player.position - transform.position;
        _rigidbody.velocity = transform.up * 2.95f;
    }

    private void ExplodePlayer(){

    }
    private void ShootPlayer()
    {
        transform.up = player.position - transform.position;

        if (!alreadyAttacked)
        {
            enemyShooter.Shoot();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
