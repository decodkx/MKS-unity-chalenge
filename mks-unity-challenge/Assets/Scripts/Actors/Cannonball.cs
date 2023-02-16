using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    [SerializeField] private float speed = 1.3f;
    [SerializeField] private int damage = 1;

    Rigidbody2D cannonballRigidbody;
    void Start()
    {
        cannonballRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cannonballRigidbody.velocity = transform.up * speed;  
    }

    private void OnCollisionEnter2D(Collision2D other) {
         if(other.gameObject.CompareTag("Enemy")){
            other.gameObject.GetComponent<Chaser>().TakeDamage(damage);
            Explode();
        }
    }
    void Explode(){
        Destroy(this.gameObject);
    }
}
