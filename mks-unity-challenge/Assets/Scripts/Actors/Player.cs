using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerHealth;
    [SerializeField] private float speed = 2.95f, drag = 2.74f; // drag armazena o valor de arrasto, quanto maior, mais lento o barco virará 
    [SerializeField] private Cannonball cannonball;
    [SerializeField] private Transform cannonPosition;
    [SerializeField] private Transform specialCannonPosition1;
    [SerializeField] private Transform specialCannonPosition2;
    [SerializeField] private Transform specialCannonPosition3;
    private float direction, thrust; 
    private Rigidbody2D playerRigidbody;

    //current speed and current direction 
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.W))
            playerRigidbody.velocity = transform.up * speed; 

        playerRigidbody.rotation -= direction/drag;

        if (Input.GetKeyDown(KeyCode.J))
            Shoot();

            if (Input.GetKeyDown(KeyCode.K))
            ActivateSpecialShot();
    }

    private void Shoot()
    {
        Vector3 pos= cannonPosition.transform.position;
        Quaternion rotation= this.transform.rotation;
        Instantiate(cannonball,pos, rotation);
    }

     private void ActivateSpecialShot()
    {
        Quaternion rotation= this.transform.rotation;
        rotation *= Quaternion.Euler(0, 0, 270); 

        Instantiate(cannonball,specialCannonPosition1.transform.position, rotation);
        Instantiate(cannonball,specialCannonPosition2.transform.position, rotation);
        Instantiate(cannonball,specialCannonPosition3.transform.position, rotation);

    }
}
