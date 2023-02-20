using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Chaser 
{
    //public static Shooter shooter;
    [SerializeField] private Transform cannonPosition;
    [SerializeField] private Cannonball cannonball;
    float offset = 0.15f;
    void Update()
    {
        
    }

    public void Shoot(){
        Vector3 pos= cannonPosition.transform.position + Vector3.up*offset;
        Quaternion rotation= this.transform.rotation;
        Instantiate(cannonball,pos, rotation);
    }
}
