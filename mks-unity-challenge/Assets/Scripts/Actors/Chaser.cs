using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    private int maxHp = 4;
    [SerializeField] private float speed = 15, yawSpeed = 15;

    private int hp;
    private bool isAgro;  //deve perseguir jogador
    float test;
    private Rigidbody2D chaserRigidbody;
    private HealthBar healthBar;
    AnimationManager animationManager;

    public float percentage;

    void Start()
    {
        hp = maxHp;
        chaserRigidbody = GetComponent<Rigidbody2D>();
        animationManager = GetComponent<AnimationManager>();
        healthBar = GetComponent<HealthBar>();
    }

    void Update()
    {
         
    }

    public void TakeDamage(int damage){
        hp -= damage;

        animationManager.ChangeSprite(4-hp);
        print(hp);
        print(maxHp);
        print(hp/maxHp);
        percentage = hp/maxHp;
        healthBar.UpdateVisuals(percentage);
    }
}