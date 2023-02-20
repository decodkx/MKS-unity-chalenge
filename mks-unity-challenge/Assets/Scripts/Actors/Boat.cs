using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public int maxHealth = 4;
    public int health;
    [SerializeField] public float speed = 3.4f;

    public Rigidbody2D rb;
    public HealthBar healthBar;
    public AnimationManager animationManager;
    private float percentage; //valor da vida para conduzir animacao de deterioramento
    void Start()
    {
        health = maxHealth;
        print(this.gameObject);
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        animationManager = GetComponent<AnimationManager>();
        healthBar = GetComponent<HealthBar>();
    }

        public void TakeDamage(int damage){
        health -= damage;

        percentage = ((float)health/maxHealth);
        if(percentage >= 0){
             healthBar.UpdateVisuals(percentage);
             animationManager.ChangeSprite(health);
        }

        if(health < 1){
            Invoke(nameof(Destroy),0.5f);
            return;
        }    
    }

    public virtual void Destroy(){
        Destroy(this.gameObject);
    }
}
