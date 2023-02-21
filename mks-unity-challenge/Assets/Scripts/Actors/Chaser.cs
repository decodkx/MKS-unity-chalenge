using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Boat
{
    public GameObject carcass;
    [SerializeField] private Explosion explosion;
    public override void Destroy(){
        healthBar.DestroyHealthBar();
        LeaveCarcass();
        Destroy(this.gameObject);
    }

    void LeaveCarcass(){

        Instantiate(carcass, transform.position, transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == 8){
            other.gameObject.GetComponent<Boat>().TakeDamage(2);
            float delay = 0;

            for(int i = 0; i < 3; i++){
                Vector3 position = transform.position + new Vector3(UnityEngine.Random.Range(-0.15f, 0.15f), UnityEngine.Random.Range(0.50f, 0.50f), 0);
                StartCoroutine(ExplodeItself(position,delay));
                delay += 0.3f;
            }
            Destroy();
        }
    }

    IEnumerator ExplodeItself(Vector3 position, float delay)
    {        
        Instantiate(explosion, position, transform.rotation);

        yield return new WaitForSeconds(delay);
    }
}
