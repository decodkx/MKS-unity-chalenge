using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D _rigidbody;
    float speed;
    public LayerMask whatIsPlayer, avoid;

    //Calculando rota
    public float opCathetus = 1f;
    public float expand = 1f;
    public GameObject needle;
    Vector3 midpoint;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public Shooter enemyShooter;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange, obstacleOnTheWay1, obstacleOnTheWay2, obstacleOnTheWay3;
    string state = "start";

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        if(gameObject.GetComponent<Shooter>() != null) enemyShooter = gameObject.GetComponent<Shooter>();
        speed = gameObject.GetComponent<Boat>().speed;
    }

    private void FixedUpdate()
    {
        //obstacleOnTheWay = Physics2D.OverlapLin
        playerInSightRange = Physics2D.OverlapCircle(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics2D.OverlapCircle(transform.position, attackRange, whatIsPlayer);

        //if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) FindPathToPlayer();
        if (playerInAttackRange && playerInSightRange) ShootPlayer();
        
    }
    private void FindPathToPlayer()
    {
        needle.transform.up = player.position - transform.position;

        obstacleOnTheWay1 = Physics2D.Linecast(transform.position, player.position, avoid);
        
        switch(state){
            case "look straight":
                ChasePlayer();
            break;
            case "look around":
                FindWayAround();
            break;
            case "go around":
                GoToMidpoint(midpoint);
            break;
            case "rest":
                //wait for obstacleOnTheWay1
            break;
            case "start":
                if(obstacleOnTheWay1){
                    state = "look around";
                } else {
                    state = "look straight";
                }
            break;
        } 
        
        if (!obstacleOnTheWay1){  //persegue o player e da uma nova chance de encontra-lo pelo findwayaround caso um obstaculo venha a ficar no caminho
        state = "look straight";
        opCathetus = 1f;
        }  
    }



    void FindWayAround(){
        while(obstacleOnTheWay1){

            midpoint = (transform.position+player.position)/2 + DegreeToVector(needle.transform.eulerAngles.z)* opCathetus;
            obstacleOnTheWay2 = Physics2D.Linecast(transform.position, midpoint, avoid);
            obstacleOnTheWay3 = Physics2D.Linecast(midpoint, player.position, avoid);
            if(!obstacleOnTheWay2 && !obstacleOnTheWay3) {
                state = "go around"; 
                break;

            }
            expand =  -1*expand;            
            opCathetus = -1*opCathetus; 

            opCathetus += expand;          // a cada loop lanca um raycast "triangular" mais afastado do caminho reto
                                          // em busca de uma passagem livre de ilhas
            if(opCathetus>33) {
                state = "rest";        //quebra loop infinito, desiste de encontrar caminho ate o player aparecer diretamente
                break;
            }
        }
    }
    private void GoToMidpoint(Vector3 tempTarget)  // vai em volta do obstaculo
    {
        if(Physics2D.Linecast(tempTarget, player.position, avoid))
            state = "look around";
        transform.up = tempTarget - transform.position;
        _rigidbody.velocity = transform.up * speed;
    }

    private void ChasePlayer()
    {
        transform.up = player.position - transform.position;
        _rigidbody.velocity = transform.up * speed;

        if(obstacleOnTheWay1)
            state = "look around";

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

    private void OnDrawGizmos()
    {
        //Alcance dos inimigos
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

        //Caminho até player
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, player.position);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (transform.position+player.position)/2 + DegreeToVector(needle.transform.eulerAngles.z)* opCathetus);
        Gizmos.DrawLine((transform.position+player.position)/2 + DegreeToVector(needle.transform.eulerAngles.z)* opCathetus, player.position);
    }

    private Vector3 DegreeToVector(float angle){   //Transforma o angulo da agulha, num vetor ortogonal a linha que conecta player e inimigo
        float radians = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0);
    }

}
