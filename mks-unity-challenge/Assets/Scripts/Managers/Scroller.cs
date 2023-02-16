using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    private Renderer _renderer;
    public float vel = 0.15f;
 
    void Start () {
        _renderer = GetComponent<Renderer> ();
    }
 
    // Update is called once per frame
    void Update () { 
        Vector2 offset = new Vector2 (vel * Time.deltaTime, vel * Time.deltaTime * 0.6f);
 
        _renderer.material.mainTextureOffset += offset;
    }
}
