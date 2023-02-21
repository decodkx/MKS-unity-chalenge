using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] boatSprites;
    private int frame;

    private void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public void ChangeSprite(int frame)
    {
        spriteRenderer.sprite = boatSprites[frame]; 
    }
}
