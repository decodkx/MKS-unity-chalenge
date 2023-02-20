using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Boat
{
    public GameObject carcass;
    private float percentage; //valor da vida para conduzir animacao de deterioramento

    public override void Destroy(){
        
        LeaveCarcass();
        Destroy(this.gameObject);
    }

    void LeaveCarcass(){

        Instantiate(carcass, transform.position, transform.rotation);
    }
}
