using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [SerializeField] public int maxHealth = 4;
    public int health;
    public int points;
    [SerializeField] public float speed = 2.8f;

    public Rigidbody2D rb;
    public HealthBar healthBar;
    AnimationManager animationManager;
    private float percentage; //valor da vida para conduzir animacao de deterioramento
    void Start()
    {
        health = maxHealth;
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
        if(this.gameObject.name == "Player")
            GameManagment.gameManager.EndGame(false);

        Destroy(this.gameObject);
    }
}
