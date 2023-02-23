using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    private float speed = 11f;
    private int damage = 1;
    [SerializeField] private GameObject explosion;
    public int target;

    Rigidbody2D cannonballRigidbody;
    void Start()
    {
        cannonballRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        cannonballRigidbody.velocity = transform.up * speed;  
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == target){
            other.gameObject.GetComponent<Boat>().TakeDamage(damage);
            Explode();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Finish"))
            Destroy(this.gameObject);
    }
    void Explode(){
        Quaternion rotation= this.transform.rotation;
        Instantiate(explosion ,transform.position, rotation);
        Destroy(this.gameObject);
    }
}
