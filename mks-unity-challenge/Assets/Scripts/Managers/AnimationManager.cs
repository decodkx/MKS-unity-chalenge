using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] boatSprites;
    [SerializeField] private int frame;

    private void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public void ChangeSprite(int frame)
    {
        spriteRenderer.sprite = boatSprites[frame]; 
    }
}
