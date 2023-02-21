using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D _rigidbody;
    public float opCathetus = 1f;
    public float expand = 1f;
    public GameObject needle;
    public LayerMask avoid;
    bool obstacleOnTheWay1, obstacleOnTheWay2, obstacleOnTheWay3, stopTrying;
    string state;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        needle.transform.up = player.position - transform.position;

        obstacleOnTheWay1 = Physics2D.Linecast(transform.position, player.position, avoid);

        switch(state){
            case "look straight":
                //chase
            break;
            case "look around":
                FindWayAround();
            break;
            case "go around":
                //
            break;
        } 

        if(obstacleOnTheWay1 && !stopTrying){
            state = "look around";
        } else {
            state = "look straigh";
            stopTrying = false;
            opCathetus = 1f;
        }  
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, player.position);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (transform.position+player.position)/2 + DegreeToVector(needle.transform.eulerAngles.z)* opCathetus);
        Gizmos.DrawLine((transform.position+player.position)/2 + DegreeToVector(needle.transform.eulerAngles.z)* opCathetus, player.position);
    }

    void FindWayAround(){
        while(obstacleOnTheWay1){
            Vector3 midpoint = (transform.position+player.position)/2 + DegreeToVector(needle.transform.eulerAngles.z)* opCathetus;
            obstacleOnTheWay2 = Physics2D.Linecast(transform.position, midpoint, avoid);
            obstacleOnTheWay3 = Physics2D.Linecast(midpoint, player.position, avoid);
            if(!obstacleOnTheWay2 && !obstacleOnTheWay3) {
                GoToMidpoint(midpoint);
                stopTrying = true; 
                break;

            }
            expand =  -1*expand;
            opCathetus = -1*opCathetus; 

            opCathetus += expand;
            print(opCathetus);

            if(opCathetus>33) {
                stopTrying = true;
                break;
            }
        }
    }

    private void GoToMidpoint(Vector3 tempTarget)
    {
        if(Physics2D.Linecast(tempTarget, player.position, avoid))
            state = "look around";
        transform.up = player.position - transform.position;
        _rigidbody.velocity = transform.up * 2.95f;
    }


    private Vector3 DegreeToVector(float angle){
        float radians = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0);
    }
}
