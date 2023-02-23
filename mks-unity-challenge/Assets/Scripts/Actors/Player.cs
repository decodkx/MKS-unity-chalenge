using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Boat
{
    public float drag = 0.45f; // drag armazena o valor de arrasto, quanto maior, mais lento o barco virará 

    #region CannonBallSpawnPosition   
    [SerializeField] private Cannonball cannonball;
    [SerializeField] private Cannonball lesserCannonball;
    [SerializeField] private Transform cannonPosition;
    [SerializeField] private Transform specialCannonPosition1;
    [SerializeField] private Transform specialCannonPosition2;
    [SerializeField] private Transform specialCannonPosition3;
    #endregion

    private float direction, thrust;

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.W))
            rb.velocity = transform.up * speed; 

        rb.rotation -= direction/drag;

        if (Input.GetKeyDown(KeyCode.J))
            Shoot();

            if (Input.GetKeyDown(KeyCode.K))
            ActivateSpecialShot();
    }

    private void Shoot()
    {
        Instantiate(cannonball,cannonPosition.transform.position, this.transform.rotation);
    }

     private void ActivateSpecialShot()
    {
        Quaternion rotation= this.transform.rotation;
        rotation *= Quaternion.Euler(0, 0, 270); 

        Instantiate(lesserCannonball,specialCannonPosition1.transform.position, rotation);
        Instantiate(lesserCannonball,specialCannonPosition2.transform.position, rotation);
        Instantiate(lesserCannonball,specialCannonPosition3.transform.position, rotation);
    }
}
